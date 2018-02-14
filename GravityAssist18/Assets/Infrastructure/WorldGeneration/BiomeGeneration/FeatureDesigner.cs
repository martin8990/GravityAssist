using UnityEngine;
using Infrastructure;
using Utility;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;

[System.Serializable]
public struct SmoothNoise
{
    [Range(100f,900f)]
    public float seed;
    [Range(0.001f,0.1f)]
    public float frequency;
};

[System.Serializable]
public struct PeakNoise
{
    [Range(10000f, 90000f)]
    public float seed;
    public float frequency;

};
[System.Serializable]
public struct StepNoise
{
    [Range(10000f, 90000f)]
    public float seed;
    public float frequency;
    public float stepStart;
    public float stepStop;
};


public class FeatureDesigner : MonoBehaviourExt
{
    public List<SmoothNoise> smoothNoise;
    public List<PeakNoise> peakNoise;
    public List<StepNoise> stepNoise;

    ComputeBuffer SmoothNoisebfr;
    ComputeBuffer peakNoisebfr;
    ComputeBuffer stepNoisebfr;

    
    public int nFeatures
    {
        get
        {
            return smoothNoise.Count + peakNoise.Count + stepNoise.Count;
        }
    }

    public void Awake()
    {
        SmoothNoisebfr = new ComputeBuffer(5, 2 * sizeof(float));
        peakNoisebfr = new ComputeBuffer(5, 2 * sizeof(float));
        stepNoisebfr = new ComputeBuffer(2, 4 * sizeof(float));

    }

    public void DesignFeatures(ComputeShader TerrainGen, int kernelIndex)
    {
        SmoothNoisebfr.SetData(smoothNoise);
        peakNoisebfr.SetData(peakNoise);
        stepNoisebfr.SetData(stepNoise);

        TerrainGen.SetInt("nSmoothNoise", smoothNoise.Count);
        TerrainGen.SetInt("nPeakNoise", peakNoise.Count);
        TerrainGen.SetInt("nStepNoise", smoothNoise.Count);

        TerrainGen.SetBuffer(kernelIndex, "SmoothNoisebfr", SmoothNoisebfr);
        TerrainGen.SetBuffer(kernelIndex, "peakNoisebfr", peakNoisebfr);
        TerrainGen.SetBuffer(kernelIndex, "stepNoisebfr", stepNoisebfr);
    }



}
