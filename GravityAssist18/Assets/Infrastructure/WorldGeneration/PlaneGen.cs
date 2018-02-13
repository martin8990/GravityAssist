using UnityEngine;

public static class PlaneGen
{
    public static GameObject GeneratePlane(int res,Material mat)
    {
        float size = res;
        var gameObject = new GameObject();
        // You can change that line to provide another MeshFilter
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = mat;
        Mesh mesh = filter.mesh;
        mesh.Clear();


        #region Vertices		
        Vector3[] vertices = new Vector3[res * res];
        for (int z = 0; z < res; z++)
        {
            // [ -size / 2, size / 2 ]
            float zPos = ((float)z / (res - 1) - .5f) * size;
            for (int x = 0; x < res; x++)
            {
                // [ -size / 2, size / 2 ]
                float xPos = ((float)x / (res - 1) - .5f) * size;
                vertices[x + z * res] = new Vector3(xPos, 0f, zPos);
            }
        }
        #endregion

        #region Normales
        Vector3[] normales = new Vector3[vertices.Length];
        for (int n = 0; n < normales.Length; n++)
            normales[n] = Vector3.up;
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

        mesh.vertices = vertices;
        mesh.normals = normales;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        return gameObject;
    }

    public static void UpdatePlane(Vector3[] vertices,GameObject gameObject)
    {
        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        //mesh.RecalculateBounds();


    }
}
