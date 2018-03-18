using System.Collections.Generic;
using UnityEngine;

public static class PlaneGen
{
    public static GameObject GeneratePlane(int res,Material mat, float[,] heightMap,Vector2Int id, int texRes)
    {
        float size = res;
        var gameObject = new GameObject();
        // You can change that line to provide another MeshFilter
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = mat;
        Mesh mesh = new Mesh();
        mesh.Clear();
        filter.mesh = mesh;

        #region Vertices		
        var vertices = UpdateHeight(res, heightMap, mesh, id, texRes);
        #endregion



        #region UVs		
        Vector2[] uvs = new Vector2[vertices.Length];
        for (int v = 0; v < res; v++)
        {
            for (int u = 0; u < res; u++)
            {
                uvs[u + v * res] = new Vector2((float)u / (res - 1), (float)v / (res - 1));
            }
        }
        #endregion

        #region Triangles
        int nbFaces = (res - 1) * (res - 1);
        int[] triangles = new int[nbFaces * 6];
        int t = 0;
        for (int face = 0; face < nbFaces; face++)
        {
            // Retrieve lower left corner from face ind
            int i = face % (res - 1) + (face / (res - 1) * res);

            triangles[t++] = i + res;
            triangles[t++] = i + 1;
            triangles[t++] = i;

            triangles[t++] = i + res;
            triangles[t++] = i + res + 1;
            triangles[t++] = i + 1;
        }
        #endregion
        
        mesh.uv = uvs;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        //mesh.RecalculateBounds();
        //mesh.RecalculateTangents();
        
        return gameObject;
    }

    public static Vector3[] UpdateHeight(int res,float[,] heightMap, Mesh mesh, Vector2Int id, int texRes)
    {
        float size = res;
        Vector3[] vertices = new Vector3[res * res];
        for (int z = 0; z < res; z++)
        {
            // [ -size / 2, size / 2 ]
            float zPos = z;
            for (int x = 0; x < res; x++)
            {
                // [ -size / 2, size / 2 ]
                float xPos = x;
                float yPos = heightMap[x + id.x * (res - 1) , (z + id.y * (res - 1))];
                vertices[x + z * res] = new Vector3(xPos, yPos, zPos);
            }
        }
        mesh.vertices = vertices;
        return vertices;
        //mesh.RecalculateNormals();
        //mesh.RecalculateBounds();


    }

    public static void UpdateNormals(GameObject gameObject)
    {
        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.RecalculateNormals();
        //mesh.RecalculateBounds();


    }

    public static void SmoothenArea(int res, GameObject gameObject, Vector2Int min,Vector2Int max, float height)
    {
        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        float size = res;
        Mesh mesh = filter.mesh;
        Vector3[] vertices = new Vector3[res * res];
        for (int z = min.y; z < max.y; z++)
        {
            // [ -size / 2, size / 2 ]
            float zPos = ((float)z / (res - 1) - .5f) * size;
            for (int x = min.x; x < max.x; x++)
            {
                // [ -size / 2, size / 2 ]
                float xPos = ((float)x / (res - 1) - .5f) * size;
                float yPos = height;
                vertices[x + z * res] = new Vector3(xPos, yPos, zPos);
            }
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        
    }


}




