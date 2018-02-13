using UnityEngine;
using Utility;
public class SurfCommander : MonoBehaviourExt
{
    public CInt meshRes;
    [Range(0.1f,0.9f)]
    public float minGradientThreshold;
    [Range(0.1f, 0.9f)]
    public float maxGradientThreshold;

    public Texture2D[] flatTextures = new Texture2D[4];
    public Texture2D[] SlopeTextures = new Texture2D[4];

    public Color[] colours = new Color[6];
    [Range(0, 1f)]
    public float[] colourStrenghts = new float[6];
    [Range(0, 1f)]
    public float[] heights = new float[6];
    [Range(0,1f)]
    public float[] blends = new float[6];

    public float scale = 1f;


    public CustomPlaneGen planeMeshGenerator;
    public void Surf(RenderTexture renderTexture,float maxHeight, float heightMult)
    {

        var planes = planeMeshGenerator.planes;
        float texScale = 1f / planes.GetLength(0);
        for (int x = 0; x < planes.GetLength(0); x++)
        {
            for (int y = 0; y < planes.GetLength(1); y++)
            {
                var mat = planes[x, y].GetComponent<MeshRenderer>().material;
                mat.SetTexture("mainTex", renderTexture);
                var offset = new Vector2( x * texScale,y * texScale);
                var texyScale = new Vector2(texScale, texScale);
                mat.SetTextureOffset("mainTex", offset);
                mat.SetTextureScale("mainTex", texyScale);
                mat.SetVector("pos", new Vector4(texScale, texScale, offset.y, offset.x));
                mat.SetFloat("maxHeight", maxHeight);
                mat.SetFloat("heightMult", heightMult);
                mat.SetFloat("minGradientThreshold", minGradientThreshold);
                mat.SetFloat("maxGradientThreshold", maxGradientThreshold);
                mat.SetFloat("scale", scale);
                for (int i = 0; i < 6; i++)
                {
                    mat.SetTexture("t" + (i + 1) + "1", flatTextures[i]);
                    mat.SetTexture("t" + (i + 1) + "2", SlopeTextures[i]);
                    mat.SetColorArray("colours", colours);
                    mat.SetFloatArray("colourStrenghts", colourStrenghts);
                    mat.SetFloatArray("heights", heights);
                    mat.SetFloatArray("blends", blends);
                    
                }

            }
        }
    }
}