using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{

    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class SplineWall : MonoBehaviour
    {
        public Spline spline;
        MeshFilter mf;
        MeshRenderer mr;
        public int nSamples = 10;
        public float offset = 0.5f;
        public bool update;
        public float[] samples;

        private void Awake()
        {
            mf = GetComponent<MeshFilter>();
            mr = GetComponent<MeshRenderer>();
        }
        private void Update()
        {
            if (update)
            {
                BuildMesh();
            }
        }
         
        public void BuildMesh()
        {
            var mesh = new Mesh();
            samples = spline.GetSamples(nSamples);

            int vertPerSide = nSamples * 2;
            int triPerSide = ((nSamples - 1) * 2) * 3;
            var verts = new Vector3[4*vertPerSide];
            var tris = new int[4*triPerSide];
            var norms = new Vector3[4*vertPerSide];
            ExtrudeFace(verts, norms, Vector3.up, 0);
            ExtrudeFace(verts, norms, Vector3.down, vertPerSide);
            ExtrudeFace(verts, norms, Vector3.right, vertPerSide*2);
            ExtrudeFace(verts, norms, Vector3.left, vertPerSide*3);

            BuildTris(tris,0,0);
            BuildTris(tris, triPerSide,vertPerSide);
            BuildTris(tris, triPerSide * 2, vertPerSide*2);
            BuildTris(tris, triPerSide * 3, vertPerSide * 3);


            mesh.vertices = verts;
            mesh.normals = norms;
            mesh.triangles = tris;

            mf.mesh = mesh;
        }

        private void BuildTris(int[] tris, int idOff,int vertIdOff)
        {
            for (int i = 0; i < nSamples - 1; i++)
            {
                tris[i * 6 + idOff] = 3 + i * 2 + vertIdOff;
                tris[i * 6 + 1 + idOff] = 1 + i * 2 + vertIdOff;
                tris[i * 6 + 2 + idOff] = 0 + i * 2 + vertIdOff;
                tris[i * 6 + 3 + idOff] = 3 + i * 2 + vertIdOff;
                tris[i * 6 + 4 + idOff] = 0 + i * 2 + vertIdOff;
                tris[i * 6 + 5 + idOff] = 2 + i * 2 + vertIdOff;
            }
        }

        private void ExtrudeFace(Vector3[] verts, Vector3[] norms,Vector3 updir, int IdOff)
        {
            for (int i = 0; i < nSamples; i++)
            {
                float t = samples[i] + 0.01f;
                verts[i * 2 + IdOff] = 0.5f * spline.Get2DNormal(t, updir) + spline.SampleSpline(t) - spline.Get2DNormal(t, new Vector3(updir.y,-updir.x,0)) * 0.5f;//offset * spline.GetNormal(t, Vector3.right);
                verts[i * 2 + 1 + IdOff] = 0.5f * spline.Get2DNormal(t, updir) + spline.SampleSpline(t) + spline.Get2DNormal(t, new Vector3(updir.y, -updir.x, 0)) * 0.5f;//offset * spline.GetNormal(t, Vector3.right);

                norms[i * 2 + IdOff] = updir;
                norms[i * 2 + 1 + IdOff] = updir;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spline.K_1,0.1f);
            Gizmos.DrawSphere(spline.K_2, 0.1f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(spline.C_Out_1, 0.1f);
            Gizmos.DrawSphere(spline.C_In_2, 0.1f);
        }

    }
}
