using UnityEngine;
using System.Collections;

public class VoxelCalculator : Singleton<VoxelCalculator> {
	
	protected VoxelCalculator () {} 
	
	public ComputeShader _CShaderGenerator;
	
	public ComputeShader _CShaderBuilder;
	
	//Maximum buffer size (triangles)
	public int _MaxSize = 21660;
	public int _Trilinear = 1;
	public int _MultiSampling = 1;
	
	//Chunk size in Z dimmension. Used in CS Builder for depth iterations.
	public int _ChunkSizeZ = 27;
	public float _Scale = 1.0f;
	
	public float _UVScale = 0.2f;
	
	public Material _DefaultMaterial;
	
	public struct Poly
	{
		//Vertex A
		public float A1,A2,A3;
		//Vertex B
		public float B1,B2,B3;
		//Vertex C
		public float C1,C2,C3;
		
		//Normals
		public float NA1,NA2,NA3;
		public float NB1,NB2,NB3;
		public float NC1,NC2,NC3;
	};
	
	
	public void CreateEmptyVolume(RenderTexture Volume, int iSize = 32)
	{
		
		int mgen_id = _CShaderGenerator.FindKernel("FillEmpty");

		_CShaderGenerator.SetTexture(mgen_id,"Result",Volume);
		
		_CShaderGenerator.Dispatch(mgen_id,1,1,iSize);
		
	}
	
	public void CreateNoiseVolume(RenderTexture Volume, Vector3 Pos, int iSize = 32, float Str = 4.0f, float NoiseA = 0.000718f, float NoiseB = 0.000632f, float NoiseC = 0.000695f)
	{
		float startTime = Time.realtimeSinceStartup;
		
		int mgen_id = _CShaderGenerator.FindKernel("Simplex3d");

		_CShaderGenerator.SetTexture(mgen_id,"Result",Volume);
		
		_CShaderGenerator.SetVector("_StartPos",new Vector4(Pos.x,Pos.y,Pos.z,0.0f));
		//_CShaderGenerator.SetFloat("_MyTime",Time.time*Speed);
		_CShaderGenerator.SetFloat("_Str",Str);
		_CShaderGenerator.SetFloat("_NoiseA",NoiseA);
		_CShaderGenerator.SetFloat("_NoiseB",NoiseB);
		_CShaderGenerator.SetFloat("_NoiseC",NoiseC);
		
		_CShaderGenerator.Dispatch(mgen_id,1,1,iSize);
		Debug.Log("Noise generation time:  " + (1000.0f*(Time.realtimeSinceStartup-startTime)).ToString()+"ms");
	}
	
	public void BuildChunkMesh(RenderTexture Volume, Mesh NewMesh)
	{
		if (Volume == null || NewMesh == null)
		{
			Debug.LogWarning("Can't build mesh '"+NewMesh+"' from '"+Volume+"' volume");
			return;
		}
		
		float startTime = Time.realtimeSinceStartup;
		
		Poly[] DataArray;

		DataArray = new Poly[_MaxSize];
		
		ComputeBuffer CBuffer = new ComputeBuffer(_MaxSize,72);
		
		//Set data to container
		CBuffer.SetData(DataArray);
		
		//Set container
		int id = _CShaderBuilder.FindKernel("CSMain");
		_CShaderBuilder.SetTexture(id,"input_volume", Volume);
		_CShaderBuilder.SetBuffer(id,"buffer", CBuffer);
		
		//Set parameters for building
		_CShaderBuilder.SetInt("_Trilinear",_Trilinear);
		_CShaderBuilder.SetInt("_Size",_ChunkSizeZ);
		_CShaderBuilder.SetInt("_MultiSampling",_MultiSampling);
		
		//Build!
		_CShaderBuilder.Dispatch(id,1,1,1);
		
		//Recieve data from container
		CBuffer.GetData(DataArray);
		
		Debug.Log("Building time: " + (1000.0f*(Time.realtimeSinceStartup-startTime)).ToString()+"ms");
		
		//Construct mesh using received data
		
		int vindex = 0;
		
		int count = 0;
		
		//Count real data length
		for (count=0;count<_MaxSize; count++)
		{
			if (DataArray[count].A1 == 0.0f && DataArray[count].B1 == 0.0f && DataArray[count].C1 == 0.0 &&
				DataArray[count].A2 == 0.0f && DataArray[count].B2 == 0.0f && DataArray[count].C2 == 0.0 &&
				DataArray[count].A3 == 0.0f && DataArray[count].B3 == 0.0f && DataArray[count].C3 == 0.0)
			{
				
				break;
			}
		}
		//Debug.Log(count+" triangles got");
		
		Vector3[] vertices = new Vector3[count*3];
		int[] tris = new int[count*3];
		Vector2[] uvs = new Vector2[count*3];
		Vector3[] normals = new Vector3[count*3];
		
		//Parse triangles
		for (int ix=0;ix<count; ix++)
		{
			
			Vector3 vPos;
			Vector3 vOffset = new Vector3(-30,-30,-30);
			//A1,A2,A3
			vPos = new Vector3(DataArray[ix].A1,DataArray[ix].A2,DataArray[ix].A3)+vOffset;
			vertices[vindex] = vPos*_Scale;
			normals[vindex] = new Vector3(DataArray[ix].NA1,DataArray[ix].NA2,DataArray[ix].NA3);
			tris[vindex] = vindex;
			uvs[vindex] = new Vector2 (vertices[vindex].z, vertices[vindex].x)*-_UVScale;			
			
			vindex++;
		
			//B1,B2,B3
			vPos =  new Vector3(DataArray[ix].B1,DataArray[ix].B2,DataArray[ix].B3)+vOffset;
			vertices[vindex] =vPos*_Scale;
			normals[vindex] = new Vector3(DataArray[ix].NB1,DataArray[ix].NB2,DataArray[ix].NB3);
			tris[vindex] = vindex;
			uvs[vindex] = new Vector2 (vertices[vindex].z, vertices[vindex].x)*-_UVScale;	
			
			vindex++;
		
			//C1,C2,C3
			vPos = new Vector3(DataArray[ix].C1,DataArray[ix].C2,DataArray[ix].C3)+vOffset;
			vertices[vindex] =  vPos*_Scale;	
			normals[vindex] = new Vector3(DataArray[ix].NC1,DataArray[ix].NC2,DataArray[ix].NC3);
			tris[vindex] = vindex;
			uvs[vindex] = new Vector2 (vertices[vindex].z, vertices[vindex].x)*-_UVScale;	
			
			vindex++;
		}
		
		//We have got all data and are ready to setup a new mesh!
		
		NewMesh.Clear();

		NewMesh.vertices = vertices;
		NewMesh.uv = uvs; //Unwrapping.GeneratePerTriangleUV(NewMesh);
		NewMesh.triangles = tris;
		NewMesh.normals = normals; //NewMesh.RecalculateNormals();
		
		;
		
		CBuffer.Dispose();
	}
}
