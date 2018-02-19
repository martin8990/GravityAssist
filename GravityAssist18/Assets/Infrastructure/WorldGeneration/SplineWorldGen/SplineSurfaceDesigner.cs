using UnityEngine;
using Utility;

public class SplineSurfaceDesigner : MonoBehaviourExt
{

    

    public void DesignSurface(GameObject[,] planes, RenderTexture texture)
    {
        int l = planes.GetLength(0);
        for (int x = 0; x < l; x++)
        {
            for (int y = 0; y < l; y++)
            {
                var mat = planes[x, y].GetComponent<MeshRenderer>().material;
                mat.SetTexture("mainTex", texture);


            }
        }
    }

}
