using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;

public class ComputeCommander : MonoBehaviourExt
{
    public bool update = true;

    public SurfCommander surfCommander;
    public Text timeText;
    public List<Biome> biomes = new List<Biome>();
    [Range(0, 0.003f)]
    public float BiomeGradient = 0.0005f;
    [Range(0, 1f)]
    public float BiomeAmplitude = 0.2f;
    [Range(100, 10000)]
    public float BiomeSmoothness = 1000f;
    [Range(10000, 50000)]
    public float BiomeSeed = 90293;
    [Range(0, 1000)]
    public float warpOffset;
    [Range(0, 1000)]
    public float warpMult;

    ComputeBuffer BiomeBuffer;
    ComputeBuffer heightMap;

    public Material TexturedMaterial;

    int nBiomes;
    int nColorZones;
    public CustomPlaneGen planeMeshGenerator;
    public ComputeShader biomeShader;
    public CInt meshRes;
    public RenderTexture renderTexture;

    public float maxHeight;
    public float heightMult;

    int texRes;
    int id;
    int Center;

    public void Start()
    {
        texRes = meshRes * (planeMeshGenerator.drawDistance * 2 + 1);
        BiomeBuffer = new ComputeBuffer(10, sizeof(float) * 5);
        heightMap = new ComputeBuffer(texRes * texRes, sizeof(float) * 4);

        heightMap.SetData(new Vector4[texRes * texRes]);
        int id = biomeShader.FindKernel("CalculateHeight");

        renderTexture = new RenderTexture(texRes, texRes, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        Center = texRes / 2;
    }

    public void Update()
    {
        if (update)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            GenerateHeight();
            sw.Stop();
            timeText.text = sw.Elapsed.ToString() + " ms";
            Textureize();
        }
        surfCommander.Surf(renderTexture, maxHeight, heightMult);
    }


    [Button]
    public void GenerateHeight()
    {
        nBiomes = biomes.Count;
        BiomeBuffer.SetData(biomes);


        var planes = planeMeshGenerator.planes;
        biomeShader.SetTexture(id, "Result", renderTexture);
        biomeShader.SetFloat("BiomeGradient", BiomeGradient);
        biomeShader.SetFloat("BiomeAmplitude", BiomeAmplitude);
        biomeShader.SetFloat("BiomeSmoothness", BiomeSmoothness);
        biomeShader.SetFloat("BiomeSeed", BiomeSeed);
        biomeShader.SetFloat("warpOffset", warpOffset);
        biomeShader.SetFloat("warpMult", warpMult);
        biomeShader.SetFloat("heightMult", heightMult);
        biomeShader.SetFloat("maxHeight", maxHeight);

        biomeShader.SetInt("nBiomes", nBiomes);
        biomeShader.SetInt("Center", Center);
        biomeShader.SetInt("texRes", texRes);

        biomeShader.SetBuffer(id, "heightMap", heightMap);
        biomeShader.SetBuffer(id, "BiomeBuffer", BiomeBuffer);

        biomeShader.Dispatch(id, texRes / 8, texRes / 8, 1);
        
    }

    [Button]
    public void Textureize()
    {
        update = false;
        var planes = planeMeshGenerator.planes;
        var hm = new Vector4[texRes * texRes];
        heightMap.GetData(hm);
        for (int x = 0; x < planes.GetLength(0); x++)
        {
            for (int y = 0; y < planes.GetLength(1); y++)
            {
                //int texRes = planeMeshGenerator.meshRes;
                var mesh = planes[x, y].GetComponent<MeshFilter>().mesh;
                var mat = planes[x, y].GetComponent<MeshRenderer>().material;
                var verts = new List<Vector3>();
                var normals = new List<Vector3>();
                mesh.GetVertices(verts);
                mesh.GetNormals(normals);
                
                for (int yv = 0; yv < meshRes; yv++)
                {
                    for (int xv = 0; xv < meshRes; xv++)
                    {
                        int hx = xv + x * (meshRes-1);


                        int hy = yv + y * (meshRes-1);
                        var vert = verts[xv + yv * meshRes];
                        Vector4 mh = hm[hx + hy * texRes];
                        verts[xv + yv * meshRes] = new Vector3(vert.x,mh.w , vert.z);
                        normals[xv + yv * meshRes] = new Vector3(mh.x, mh.y, mh.z);
                    }
                }


                mesh.SetVertices(verts);
                mesh.SetNormals(normals);
                planes[x, y].GetComponent<MeshRenderer>().material = TexturedMaterial;

                //var scale = planes[x, y].transform.localScale;
                //planes[x, y].transform.localScale = new Vector3(scale.x, heightMult, scale.z);

            }
        }
    }

}
