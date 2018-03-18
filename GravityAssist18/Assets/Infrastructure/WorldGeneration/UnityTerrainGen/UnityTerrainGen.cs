using UnityEngine;
using Utility;
using System.Collections;

public class UnityTerrainGen : MonoBehaviourExt
{

    public CInt texRes;

    public ComputeShader terrainShader;
    public BiomeDesigner biomeDesigner;
    public UTSurfaceDesigner surfaceDesigner;
    public LayerMask terrainLayer;

    public Terrain terrain;
    public HeightMap heightMap2d;
    [Range(1, 100)]
    public float heightMult = 50;

    public bool update = true;

    int kernelId;
    int Center;
    RenderTexture renderTexture;
    ComputeBuffer heightMapbfr;
    float[] heightMap;
    bool ready;
    bool done;

    [Button]
    public void RegenerateTerrain()
    {
        heightMap = new float[texRes * texRes];
        heightMapbfr = new ComputeBuffer(texRes * texRes, sizeof(float));
        heightMapbfr.SetData(heightMap);
        kernelId = terrainShader.FindKernel("CalculateHeight");

        renderTexture = new RenderTexture(texRes, texRes, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        Center = texRes / 2;
        StartCoroutine(GenerateTerrain());

    }
    private void Update()
    {
        if (ready && !done)
        {
            //            surfaceDesigner.DesignSurface(planes);
        }
    }

    public IEnumerator GenerateTerrain()
    {
        biomeDesigner.GenerateHeight(terrainShader, kernelId);
        GenerateHeightMap();
        heightMap2d.heightMap = heightMap.Conv1D2D(texRes);
        terrain.terrainData.SetHeights(0, 0, heightMap2d.heightMap);
        surfaceDesigner.DesignSurface(terrain);
        yield return null;
        //yield return StartCoroutine(meshEditor.GenerateTerrain());
        //planes = meshEditor.planes;
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


    public void GenerateHeightMap()
    {
        terrainShader.SetTexture(kernelId, "Result", renderTexture);

        terrainShader.SetInt("Center", Center);
        terrainShader.SetInt("texRes", texRes);

        terrainShader.SetFloat("heightMult", heightMult);

        terrainShader.SetBuffer(kernelId, "heightMap", heightMapbfr);
        terrainShader.Dispatch(kernelId, texRes / 8, texRes / 8, 1);

        heightMapbfr.GetData(heightMap);

    }

    public void FinalizeTerrain()
    {
        done = true;
        //planes.Iter2D((x) => x.AddComponent<MeshCollider>());
        //planes.Iter2D((x) => x.layer = 10);

        //NavMeshManager.UpdateNavMesh();

    }


}
