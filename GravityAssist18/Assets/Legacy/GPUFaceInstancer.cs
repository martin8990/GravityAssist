//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//public class GPUFaceInstancer : MonoBehaviour
//{
//    public Mesh FaceMesh;
//    public Material mat;
    
//    public Matrix4x4[] faceTransforms = new Matrix4x4[0];
//    bool updating;
//    private void Update()
//    {

//        Graphics.DrawMeshInstanced(FaceMesh, 0, mat, faceTransforms);
//    }
//    public void updateFaceTransform(Dictionary<int, Matrix4x4> lookup)
//    {
//        faceTransforms = lookup.Values.ToArray();
//    }


  
//}
