using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections;


public class TerrainGenerator : MonoBehaviourExt
{
       
    public CInt texRes;
    
    public ComputeShader terrainShader;
    public BiomeDesigner biomeDesigner;
    public TerrainMeshEditor meshEditor;
    public TexturedSurfaceDesigner surfaceDesigner;
    public LayerMask terrainLayer;

    public HeightMap heightMap2d;
    [Range(1,100)]
    public float heightMult = 50;

    public bool update = true;

    int kernelId;
    int Center;
    RenderTexture renderTexture;
    ComputeBuffer heightMapbfr;
    float[] heightMap;
    GameObject[,] planes;
    bool ready;
    bool done;

    [Button]
    public void StartTerrainGeneration()
    {
        meshEditor.gameObject.DestroyKids();
        
        GenerateTerrain();

    }
    //private void Update()
    //{
    //    if (ready && !done)
    //    {
    //        surfaceDesigner.DesignSurface(planes);

    //    }
    //}
    public void GenerateTerrain()
    {
        biomeDesigner.GenerateHeight(terrainShader, kernelId);
        GenerateHeightMap();

        meshEditor.GenerateTerrain();
        planes = meshEditor.planes;
        //surfaceDesigner.DesignSurface(planes);
        //ready = true;
        //if (update)
        //{
        //    StartCoroutine(UpdateHeight());
        //    StartCoroutine(UpdateNormals());
        //}
        //else
        //{
        //    FinalizeTerrain();
        //}
    }
    [Button]
    public void Start()
    {
        var planes1d = meshEditor.gameObject.GetKids();
        surfaceDesigner.DesignSurface(planes1d);
        biomeDesigner.GenerateHeight(terrainShader, kernelId);

        GenerateHeightMap();
    }
    

    //public IEnumerator GenerateTerrain()
    //{
    //    biomeDesigner.GenerateHeight(terrainShader, kernelId);
    //    GenerateHeightMap();
    //    heightMap2d.heightMap = heightMap.Conv1D2D(texRes);
    //    yield return StartCoroutine(meshEditor.GenerateTerrain());
    //    planes = meshEditor.planes;
    //    surfaceDesigner.DesignSurface(planes);
    //    ready = true;
    //    if (update)
    //    {
    //        StartCoroutine(UpdateHeight());
    //        StartCoroutine(UpdateNormals());
    //    }
    //    else
    //    {
    //        FinalizeTerrain();
    //    }


    //}

    public IEnumerator UpdateHeight()
    {
        biomeDesigner.GenerateHeight(terrainShader, kernelId);
        GenerateHeightMap();
        yield return StartCoroutine(meshEditor.UpdateHeight(planes));
        
        if (update)
        {
            StartCoroutine(UpdateHeight());          
        }
    }
    public IEnumerator UpdateNormals()
    {
        yield return StartCoroutine(meshEditor.UpdateNormals(planes));
        if (update)
        {
            StartCoroutine(UpdateNormals());
        }
    }

    public void GenerateHeightMap()
    {
        heightMap = new float[texRes * texRes];
        heightMapbfr = new ComputeBuffer(texRes * texRes, sizeof(float));
        heightMapbfr.SetData(heightMap);
        kernelId = terrainShader.FindKernel("CalculateHeight");

        renderTexture = new RenderTexture(texRes, texRes, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        Center = texRes / 2;
        terrainShader.SetTexture(kernelId, "Result", renderTexture);

        terrainShader.SetInt("Center", Center);
        terrainShader.SetInt("texRes", texRes);

        terrainShader.SetFloat("heightMult", heightMult);

        terrainShader.SetBuffer(kernelId, "heightMap", heightMapbfr);      
        terrainShader.Dispatch(kernelId, texRes / 8, texRes / 8, 1);

        heightMapbfr.GetData(heightMap);
        heightMap2d.heightMap = heightMap.Conv1D2D(texRes);
    }
    [Button]
    public void FinalizeTerrain()
    {
        done = true;

        var planes1d = meshEditor.gameObject.GetKids();
        planes1d.Iter((x) => x.AddComponent<MeshCollider>());
        planes1d.Iter((x) => x.layer = 10);

     //   NavMeshManager.UpdateNavMesh();
       
    }

}
