using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
public class BiomeGenerator : MonoBehaviour
{
    public Text timeText;
    public List<Biome> biomes = new List<Biome>();
    [Range(0,0.003f)]
    public float BiomeGradient = 0.0005f;
    [Range(0, 1f)]
    public float BiomeAmplitude = 0.2f;
    [Range(100, 10000)]

    public float BiomeSmoothness = 1000f;
    [Range(1,5)]
    public float BiomeFractals =  4f;
    [Range(10000, 50000)]
     public float BiomeSeed = 90293;
    ComputeBuffer BiomeBuffer;
    int nBiomes;


    public PlaneMeshGenerator planeMeshGenerator;
    public ComputeShader biomeShader;
    public int TextureResolution;
    public RenderTexture renderTexture;
    int id;
    int Center;
    public float texScale;

    

    public void Start()
    {
        
        
        BiomeBuffer = new ComputeBuffer(10,sizeof(float) * 9);
        int id = biomeShader.FindKernel("CalculateHeight");

        renderTexture = new RenderTexture(TextureResolution, TextureResolution, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        Center = TextureResolution / 2;
    }

    public void Update()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        GenerateHeight();
        sw.Stop();
        timeText.text = sw.Elapsed.ToString() + " ms";
    }

    [Button]
    public void GenerateHeight()
    {
        nBiomes = biomes.Count;
        BiomeBuffer.SetData(biomes);


        var planes = planeMeshGenerator.planes;
        biomeShader.SetTexture(id, "Result", renderTexture);
        biomeShader.SetInt("nBiomes", nBiomes);
        biomeShader.SetInt("Center", Center);
        biomeShader.SetFloat("BiomeGradient", BiomeGradient);
        biomeShader.SetFloat("BiomeAmplitude", BiomeAmplitude);
        biomeShader.SetFloat("BiomeSmoothness", BiomeSmoothness);
        biomeShader.SetFloat("BiomeFractals", BiomeFractals);
        biomeShader.SetFloat("BiomeSeed", BiomeSeed);

        biomeShader.SetBuffer(id, "BiomeBuffer", BiomeBuffer);
        biomeShader.Dispatch(id, TextureResolution / 8, TextureResolution / 8, 1);

        int scale = TextureResolution / planes.GetLength(0);
        for (int x = 0; x < planes.GetLength(0); x++)
        {
            for (int y = 0; y < planes.GetLength(1); y++)
            {
                var mat = planes[x, y].GetComponent<MeshRenderer>().material;
               mat.SetTexture("mainTex", renderTexture);
                var offset = new Vector2(texScale * (planeMeshGenerator.drawDistance - x + 1), texScale * y);
                var texyScale = new Vector2(texScale, texScale);
                mat.SetTextureOffset("mainTex", offset);
                mat.SetTextureScale("mainTex", texyScale);
                mat.SetVector("pos", new Vector4(texyScale.x, texyScale.y, texyScale.x * x, offset.y));
            }
        }
       
    }

}
