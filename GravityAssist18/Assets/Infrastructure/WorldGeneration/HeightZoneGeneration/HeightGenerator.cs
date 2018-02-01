using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;

public class HeightGenerator : MonoBehaviour
{
    public List<ContourPoint> heightPositions = new List<ContourPoint>();
    public List<HeightContour> heightContours = new List<HeightContour>();

    ComputeBuffer CPointBuffer;
    ComputeBuffer HCBuffer;

    public PlaneMeshGenerator planeMeshGenerator;
    public ComputeShader HeightZoneGeneration;
    public int TextureResolution;
    public RenderTexture renderTexture;
    int id;
    int nContours;
    public int nPosInContours = 4;
    

    public void Start()
    {
        
        CPointBuffer = new ComputeBuffer(40, sizeof(float) * 4);
        HCBuffer = new ComputeBuffer(10,sizeof(float) * 5 + sizeof(int) * 1);
        int id = HeightZoneGeneration.FindKernel("CalculateHeight2");

        renderTexture = new RenderTexture(TextureResolution, TextureResolution, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
    }

    public void Update()
    {
        GenerateHeight();
    }

    [Button]
    public void GenerateHeight()
    {
        nContours = heightContours.Count;
        CPointBuffer.SetData(heightPositions);
        HCBuffer.SetData(heightContours);

        var planes = planeMeshGenerator.planes;
        HeightZoneGeneration.SetTexture(id, "Result", renderTexture);
        HeightZoneGeneration.SetInt("nContours", nContours);
        HeightZoneGeneration.SetInt("nPosInContours", nPosInContours);

        HeightZoneGeneration.SetBuffer(id, "CPointBuffer", CPointBuffer);
        HeightZoneGeneration.SetBuffer(id, "HCBuffer", HCBuffer);
        HeightZoneGeneration.Dispatch(id, TextureResolution / 8, TextureResolution / 8, 1);
        planes[0, 0].GetComponent<MeshRenderer>().material.SetTexture("mainTex", renderTexture);
       
    }

}
