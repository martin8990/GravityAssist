using UnityEngine;
using Infrastructure;
using Utility;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections;

public class SplineTerrainGenerator : MonoBehaviourExt
{
       
    public CInt texRes;
    
    public ComputeShader terrainShader;
    public SplineDesigner splineDesigner;
    public TerrainMeshEditor meshEditor;
    public SplineSurfaceDesigner surfaceDesigner;

    public bool update = true;

    int kernelId;
    int Center;

    RenderTexture renderTexture;

    GameObject[,] planes;
    bool ready;
    bool done;

    public void Start()
    {

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
            surfaceDesigner.DesignSurface(planes,renderTexture);

        }
    }

    public IEnumerator GenerateTerrain()
    {
        splineDesigner.designSplines(terrainShader, kernelId);
        DispatchComputeShader();
        yield return StartCoroutine(meshEditor.GenerateTerrain(new float[texRes*texRes]));
        planes = meshEditor.planes;
        surfaceDesigner.DesignSurface(planes,renderTexture);
        ready = true;
              

    }
    

    public void DispatchComputeShader()
    {
        terrainShader.SetTexture(kernelId, "Result", renderTexture);
        terrainShader.SetInt("Center", Center);
        terrainShader.SetInt("texRes", texRes);
        terrainShader.Dispatch(kernelId, texRes / 8, texRes / 8, 1);
       
    }

    

}
