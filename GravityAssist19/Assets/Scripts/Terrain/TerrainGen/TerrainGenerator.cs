using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections;

[ExecuteInEditMode]
public class TerrainGenerator : MonoBehaviourExt
{
    public bool safety;
    int texRes;
    
    public ComputeShader terrainShader;
    public BiomeDesigner biomeDesigner;
    public Terrain terrain;
   
    [Range(0,1)]
    public float heightMult = 1;
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
    public void GenerateTerrain()
    {
        if (!safety)
        {
            texRes = terrain.terrainData.heightmapResolution;
            heightMap = new float[texRes * texRes];
            heightMapbfr = new ComputeBuffer(texRes * texRes, sizeof(float));
            heightMapbfr.SetData(heightMap);
            UpdateTerrain();
            ready = true;
        }
    }
    public void Update()
    {
        if (!safety && update && ready)
        {
            UpdateTerrain();
        }
    }

    public void UpdateTerrain()
    {
        kernelId = terrainShader.FindKernel("CalculateHeight");

        Center = texRes / 2;

        biomeDesigner.Design(terrainShader, kernelId);

        terrainShader.SetInt("Center", Center);
        terrainShader.SetInt("texRes", texRes);

        terrainShader.SetFloat("heightMult", heightMult);

        terrainShader.SetBuffer(kernelId, "heightMap", heightMapbfr);
        terrainShader.Dispatch(kernelId, (texRes + 7) / 8, (texRes + 7) / 8, 1);

        heightMapbfr.GetData(heightMap);


        terrain.terrainData.SetHeights(0, 0, heightMap.Map1D2D((x) => x, texRes));
    }



}
