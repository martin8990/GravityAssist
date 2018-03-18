using UnityEngine;
using Utility;
public class UTSurfaceDesigner : MonoBehaviour
{

    [Range(0, 1f)]
    public float[] heights;
    [Range(0, 1f)]
    public float[] hblends;

    [Range(0.001f, 0.1f)]
    public float[] freqs;
    [Range(20000, 100000)]
    public float[] seeds;
    public Color[] colours;

    public float gblend;
    public float mingrad;

    public float maxHeight = 1;
    public float maxGrad = 0.1f;


    public void DesignSurface(Terrain terrain)
    {
                var mat = terrain.materialTemplate;
                mat.SetColorArray("colours", colours);
                mat.SetFloatArray("hblends", hblends);
                mat.SetFloat("blend", gblend);
                mat.SetFloatArray("heights", heights);

                mat.SetFloatArray("freqs", freqs);
                mat.SetFloatArray("seeds", seeds);
                mat.SetFloat("maxHeight", maxHeight);
                mat.SetFloat("maxGrad", maxGrad);
                mat.SetFloat("mingrad", mingrad);
     }

}




