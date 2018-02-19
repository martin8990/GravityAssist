using System.Collections.Generic;
using UnityEngine;
using Utility;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]

public class ConstructionMesh : MonoBehaviour
{
    public Mesh visualMesh;
    public MeshRenderer meshRenderer;
    public MeshCollider meshCollider;
    public MeshFilter meshFilter;

    public Color color;
    public NodeType myType;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        meshFilter = GetComponent<MeshFilter>();
    }

    public virtual void CreateVisualMesh(GameNode[,,] map)
    {
        visualMesh = new Mesh();

        List<Vector3> verts = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        List<int> tris = new List<int>();

        Debug.Log(map.GetLength(0));
        Debug.Log(map.GetLength(1));
        Debug.Log(map.GetLength(2));

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int z = 0; z < map.GetLength(2); z++)
                {
                    if (map[x, y, z].nodeType != myType)
                    {
                        continue;
                    }
                    int prevHeight = 0;
                    for (int yl = 0; yl < y; yl++)
                    {
                        prevHeight += 1;//map[x, yl, z].height;
                    }
                    Vector3 dx = Vector3.right;
                    Vector3 dy = 1 * Vector3.up;
                    Vector3 dz = Vector3.forward;
                    Vector3Int pSize = new Vector3Int(x, prevHeight, z);

                    BuildFace(pSize, dy, dz, false, verts, uvs, tris);
                    BuildFace(pSize + dx, dy, dz, true, verts, uvs, tris);

                    BuildFace(pSize, dz, dx, false, verts, uvs, tris);
                    BuildFace(pSize + dy, dz, dx, true, verts, uvs, tris);

                    BuildFace(pSize, dy, dx, true, verts, uvs, tris);
                    BuildFace(pSize + dz, dy, dx, false, verts, uvs, tris);


                }
            }
        }

        visualMesh.vertices = verts.ToArray();
        visualMesh.uv = uvs.ToArray();
        visualMesh.triangles = tris.ToArray();
  //      visualMesh.RecalculateBounds();
  //      visualMesh.RecalculateNormals();

        meshFilter.mesh = visualMesh;
        //meshCollider.sharedMesh = visualMesh;

    }
    public virtual void BuildFace(Vector3 corner, Vector3 up, Vector3 right, bool reversed, List<Vector3> verts, List<Vector2> uvs, List<int> tris)
    {
        int index = verts.Count;

        verts.Add(corner);
        verts.Add(corner + up);
        verts.Add(corner + up + right);
        verts.Add(corner + right);

        uvs.Add(new Vector2(0, 0));
        uvs.Add(new Vector2(0, 1));
        uvs.Add(new Vector2(1, 1));
        uvs.Add(new Vector2(1, 0));

        if (reversed)
        {
            tris.Add(index + 0);
            tris.Add(index + 1);
            tris.Add(index + 2);
            tris.Add(index + 2);
            tris.Add(index + 3);
            tris.Add(index + 0);
        }
        else
        {
            tris.Add(index + 1);
            tris.Add(index + 0);
            tris.Add(index + 2);
            tris.Add(index + 3);
            tris.Add(index + 2);
            tris.Add(index + 0);
        }

    }
}


