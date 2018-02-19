using UnityEngine;
using System.Collections.Generic;

public class SplineDesigner : MonoBehaviour
{
    public List<Spline> splines = new List<Spline>();
    ComputeBuffer splineBuffer;

    int nSplines;
    public float maxRadius = 100;

    public void Awake()
    {
        splineBuffer = new ComputeBuffer(10, sizeof(float) * 12);
    }

    public void designSplines(ComputeShader terrainShader, int id)
    {
        nSplines = splines.Count;
        splineBuffer.SetData(splines);
        terrainShader.SetFloat("maxRadius", maxRadius);
        terrainShader.SetInt("nSplines", nSplines);
        terrainShader.SetBuffer(id, "splineBuffer", splineBuffer);

    }


}
