//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using System.Diagnostics;
//[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(MeshCollider))]
//[RequireComponent(typeof(MeshFilter))]
//public class BuildingMatrix : MonoBehaviour
//{

//    public float[,,] map;
//    public Mesh visualMesh;
//    protected MeshRenderer meshRenderer;
//    protected MeshCollider meshCollider;
//    protected MeshFilter meshFilter;
//    public int res = 10;
//    public int height = 1;
//    public Text text;
//    public int FacesPerMesh;

//    void Start()
//    {
//        meshRenderer = GetComponent<MeshRenderer>();
//        meshCollider = GetComponent<MeshCollider>();
//        meshFilter = GetComponent<MeshFilter>();
//        visualMesh = new Mesh();
//        visualMesh.MarkDynamic();
//        map = new float[res, height, res];

//        for (int x = 0; x < res; x++)
//        {
//            for (int z = 0; z < res; z++)
//            {
//                map[x, 0, z] = 1;
//            }
//        }
//    }

   
//    public void CreateVisualMesh()
//    {
        
//        List<Vector3> verts = new List<Vector3>();
//        List<Vector2> uvs = new List<Vector2>();
//        List<int> tris = new List<int>();


//        for (int x = 0; x < res; x++)
//        {
//            for (int y = 0; y < height; y++)
//            {
//                for (int z = 0; z < res; z++)
//                {
//                    if (map[x, y, z] == 0) continue;

//                    float block = map[x, y, z];
//                    var p = new Vector3(x, y, z);
//                    var dx = Vector3.right;
//                    var dy = Vector3.up;
//                    var dz = Vector3.forward;                    
//                    // Left wall
//                    if (IsVisible(x - 1, y, z, block))
//                    {
//                        BuildFace(p, dy, dz, false, verts, uvs, tris);
//                    }
//                    // Right wall
//                    if (IsVisible(x + 1, y, z, block))
//                    {
//                        BuildFace(p+dx, dy, dz, true, verts, uvs, tris);
//                    }
//                    // Bottom wall
//                    if (IsVisible(x, y - 1, z, block))
//                    {
//                        BuildFace(p, dz, dx, false, verts, uvs, tris);
//                    }
//                    // Top wall
//                    if (IsVisible(x, y + 1, z, block))
//                    {
//                        BuildFace(p + dy, dz, dx, true, verts, uvs, tris);
//                    }
//                    // Back
//                    if (IsVisible(x, y, z - 1, block))
//                    {
//                        BuildFace(p, dy, dx, true, verts, uvs, tris);
//                    }
//                    // Front
//                    if (IsVisible(x, y, z + 1, block))
//                    {
//                        BuildFace(p + dz, dy, dx, false, verts, uvs, tris);
//                    }
//                }
//            }
//        }

//        visualMesh.SetVertices(verts);
//        visualMesh.triangles = tris.ToArray();
//        visualMesh.RecalculateBounds();
//        visualMesh.RecalculateNormals();

//        meshFilter.mesh = visualMesh;
//        meshCollider.sharedMesh = visualMesh;
//    }



//    public virtual void BuildFace(Vector3 corner, Vector3 up, Vector3 right, bool reversed, List<Vector3> verts, List<Vector2> uvs, List<int> tris)
//    {
//        int index = verts.Count;

//        verts.Add(corner);
//        verts.Add(corner + up);
//        verts.Add(corner + up + right);
//        verts.Add(corner + right);

//        uvs.Add(new Vector2(0, 0));
//        uvs.Add(new Vector2(0, 1));
//        uvs.Add(new Vector2(1, 1));
//        uvs.Add(new Vector2(1, 0));

//        if (reversed)
//        {
//            tris.Add(index + 0);
//            tris.Add(index + 1);
//            tris.Add(index + 2);
//            tris.Add(index + 2);
//            tris.Add(index + 3);
//            tris.Add(index + 0);
//        }
//        else
//        {
//            tris.Add(index + 1);
//            tris.Add(index + 0);
//            tris.Add(index + 2);
//            tris.Add(index + 3);
//            tris.Add(index + 2);
//            tris.Add(index + 0);
//        }

//    }
//    public bool IsVisible(int x, int y, int z,float Origin)
//    {
//        float brick = GetBlock(x, y, z);
//        return Origin > brick;

//    }
//    public float GetBlock(int x, int y, int z)
//    {
//        if ((x < 0) || (y < 0) || (z < 0) || (y >= height) || (x >= res) || (z >= res))
//            return 0;
//        return map[x, y, z];
//    }

//}


