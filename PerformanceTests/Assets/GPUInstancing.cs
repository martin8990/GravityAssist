using UnityEngine;
using Utility;
public class GPUInstancing : MonoBehaviour
{
    public Mesh mesh;
    public Material mat;
    public int layer;
    public int planes;

    public Transform[] transforms;

    public Matrix4x4 myMatrix;

    public void Update()
    {
        myMatrix = transform.localToWorldMatrix;
        Graphics.DrawMeshInstanced(mesh,0, mat, transforms.Map((x) => x.localToWorldMatrix) ,transforms.Length);
    }

}
