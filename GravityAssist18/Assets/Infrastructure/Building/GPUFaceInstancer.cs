using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Diagnostics;
public class GPUFaceInstancer : MonoBehaviour
{
    public Mesh FaceMesh;
    public Material mat;
   

    bool updating;
    private void Update()
    {
       
    }
    public void DrawFaceTransforms(Matrix4x4[,][] faceTransforms)
    {
        for (int x = 0; x < faceTransforms.GetLength(0); x++)
        {
            for (int y = 0; y < faceTransforms.GetLength(1); y++)
            {
                Graphics.DrawMeshInstanced(FaceMesh, 0, mat, faceTransforms[x, y]);
            }
        }

    }



}
