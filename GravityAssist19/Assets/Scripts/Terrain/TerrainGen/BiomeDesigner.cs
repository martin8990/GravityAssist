using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;

public class BiomeDesigner : MonoBehaviourExt
{
    [Range(0, 0.03f)]
    public float BiomeGradient = 0.0005f;
    [Range(0, 1f)]
    public float BiomeAmplitude = 0.2f;
    [Range(100,1000)]
    public float BiomeSmoothness= 1000f;
    [Range(10f,100f)]
    public float BiomeSeed = 10;
    [Range(0, 1000)]
    public float warpOffset;
    [Range(0, 1000)]
    public float warpMult;

    public List<Biome> biomes = new List<Biome>();
    ComputeBuffer BiomeBuffer;
        
    int nBiomes;
  
 

    public void Design(ComputeShader terrainShader, int id)
    {
        BiomeBuffer = new ComputeBuffer(10, sizeof(float) * 5);
        nBiomes = biomes.Count;
        BiomeBuffer.SetData(biomes);


        terrainShader.SetFloat("BiomeGradient", BiomeGradient);
        terrainShader.SetFloat("BiomeAmplitude", BiomeAmplitude);
        terrainShader.SetFloat("BiomeSmoothness", BiomeSmoothness);
        terrainShader.SetFloat("BiomeSeed", BiomeSeed);
        terrainShader.SetFloat("warpOffset", warpOffset);
        terrainShader.SetFloat("warpMult", warpMult);

        terrainShader.SetInt("nBiomes", nBiomes);
        terrainShader.SetBuffer(id, "BiomeBuffer", BiomeBuffer);
        
    }

  
}
