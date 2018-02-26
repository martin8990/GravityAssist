using UnityEngine;
using System.Collections;


[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]

public class VoxelChunk : MonoBehaviour {
	
	public int _SizeZ = 27;
	
	public float Size
	{
		get { return transform.localScale.z*(_SizeZ)*20.0f; }
	}

	private RenderTexture DensityVolume;
	
	
	// Use this for initialization
	void Start () {
		float startTime = Time.realtimeSinceStartup;
		
		DensityVolume = new RenderTexture(_SizeZ+4,_SizeZ+4,0,RenderTextureFormat.RFloat,RenderTextureReadWrite.sRGB);
		
		DensityVolume.volumeDepth = _SizeZ+4;
		DensityVolume.isVolume = true;
		DensityVolume.enableRandomWrite = true;
		DensityVolume.filterMode = FilterMode.Point;
		DensityVolume.wrapMode = TextureWrapMode.Clamp;
		DensityVolume.Create();
		
	 	MeshFilter MF = GetComponent<MeshFilter>();
		MeshRenderer MR = GetComponent<MeshRenderer>();
		
		if (MF.sharedMesh == null)
			MF.sharedMesh = new Mesh();
			
		VoxelCalculator.Instance.CreateEmptyVolume(DensityVolume,_SizeZ+4);
		VoxelCalculator.Instance.CreateNoiseVolume(DensityVolume,transform.position,_SizeZ+4);
		VoxelCalculator.Instance.BuildChunkMesh(DensityVolume, MF.sharedMesh);
		
		MR.material = VoxelCalculator.Instance._DefaultMaterial;
		Debug.Log("CHUNK CREATION TIME = " + (1000.0f*(Time.realtimeSinceStartup-startTime)).ToString()+"ms");
	}
	
	// Update is called once per frame
	void Update () {
		DrawVoxel(Color.red,transform.position);
	}
	
	void OnDestroy()
	{
		if (DensityVolume!=null){
			
			DensityVolume.Release();
		}
		
	}
	
	public void DrawVoxel(Color Col, Vector3 Pos, float Dur = 0.0f)
	{
		Vector3 A,B,C,D,E,F,G,H;
				
		A = Pos;
		
		B = A + transform.right*Size;
		C = A + transform.up*Size;
		D = A + transform.forward*Size;
	
		E = A + transform.right*Size + transform.forward*Size;
		F = A + transform.right*Size + transform.up*Size;
		
		G = A + transform.right*Size + transform.up*Size + transform.forward*Size;
		H = A + transform.up*Size + transform.forward*Size;
				
		Debug.DrawLine(A, B, Col,Dur);
		Debug.DrawLine(B, E, Col,Dur);
		Debug.DrawLine(E, D, Col,Dur);
		Debug.DrawLine(D, A, Col,Dur);
	
		Debug.DrawLine(C, F, Col,Dur);
		Debug.DrawLine(F, G, Col,Dur);
		Debug.DrawLine(G, H, Col,Dur);
		Debug.DrawLine(H, C, Col,Dur);
	
		Debug.DrawLine(A, C, Col,Dur);
		Debug.DrawLine(D, H, Col,Dur);
		Debug.DrawLine(E, G, Col,Dur);
		Debug.DrawLine(B, F, Col,Dur);
	}
}
