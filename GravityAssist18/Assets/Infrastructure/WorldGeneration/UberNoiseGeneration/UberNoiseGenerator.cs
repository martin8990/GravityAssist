using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;

[System.Serializable]
public struct NoiseLayer
{
    [Range(0, 1)]
    public float amplitude;
    [Range(40, 10000)]
    public float smoothness;
    [Range(1, 5)]
    public float fractals;
    [Range(1000, 10000)]
    public float seed;

    public Vector2 Warp;
    [Range(0,1000)]
    public float mult;
    [Range(-10, 10)]
    public float sharpness;
    public Color color;
}


public class UberNoiseGenerator : MonoBehaviour
{
    public Text timeText;
    ComputeBuffer NoiseLayerBuffer;
    int nLayers;
    public List<NoiseLayer> noiseLayers;
    public PlaneMeshGenerator planeMeshGenerator;
    public ComputeShader uberNoiseShader;
    public int TextureResolution;
    public RenderTexture renderTexture;
    int id;
    int Center;


    public void Start()
    {
       
        NoiseLayerBuffer = new ComputeBuffer(10,sizeof(float) * 12);
        int id = uberNoiseShader.FindKernel("CalculateHeight");

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
        nLayers = noiseLayers.Count;
        NoiseLayerBuffer.SetData(noiseLayers);


        var planes = planeMeshGenerator.planes;
        uberNoiseShader.SetTexture(id, "Result", renderTexture);
        uberNoiseShader.SetInt("nLayers", nLayers);
        uberNoiseShader.SetInt("Center", Center);
        
        uberNoiseShader.SetBuffer(id, "NoiseLayerBuffer", NoiseLayerBuffer);
        uberNoiseShader.Dispatch(id, TextureResolution / 8, TextureResolution / 8, 1);

        int scale = TextureResolution / planes.GetLength(0);
        float texScale = 1f / planes.GetLength(0);
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
                mat.SetVector("pos", new Vector4(texScale, texScale, offset.y, offset.x));
            }
        }
       
    }

}
