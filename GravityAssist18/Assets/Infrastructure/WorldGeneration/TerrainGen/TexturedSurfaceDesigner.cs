using UnityEngine;
using Utility;
using System.Linq;
[System.Serializable]
public class TextureZone
{
    [Range(0f,1f)]
    public float height;
    [Range(0f, 1f)]
    public float blend;
    public Texture2D Flat;
    public Texture2D Gradient;
}

public class TexturedSurfaceDesigner : MonoBehaviourExt
{
    public TextureZone[] textureZones = new TextureZone[1];

    public float gblend;
    public float mingrad;
    public float scale;

    public float maxHeight = 1;
    public float maxGrad = 0.1f;
    public Material mat;


    public void DesignSurface(GameObject[] planes)
    {
        int l = planes.Length;

        mat.SetFloatArray("heights", textureZones.Select((x) => x.height).ToArray());
        mat.SetFloatArray("hblends", textureZones.Select((x) => x.blend).ToArray());

        for (int i = 0; i < textureZones.Length; i++)
        {
            mat.SetTexture("t" + (i + 1) + "1", textureZones[i].Flat);
            mat.SetTexture("t" + (i + 1) + "2", textureZones[i].Gradient);
        }

        mat.SetFloat("blend", gblend);
        mat.SetFloat("scale", scale);

        mat.SetFloat("maxHeight", maxHeight);
        mat.SetFloat("maxGrad", maxGrad);
        mat.SetFloat("mingrad", mingrad);
        for (int x = 0; x < l; x++)
        {
            planes[x].GetComponent<MeshRenderer>().sharedMaterial = mat;
        }
    }

}
