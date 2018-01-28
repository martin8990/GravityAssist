using UnityEngine;
using Utility;
using System.Collections.Generic;
namespace Infrastructure
{




    public class VonoroiMapper : MonoBehaviour
    {
        public VonoroiGenerator voronoiGenerator;
        public PlaneMeshGenerator planeMeshGenerator;
        public RenderTexture[,] voronoiMaps;

        public ComputeShader vonoroiMapShader;
        public RenderTexture test;


        [Button]
        public void MapVoronoi()
        {
            var terrainPoints = voronoiGenerator.terrainPoints.ToArray();
            var pointsV2 = ArrayMap.Map(terrainPoints, (x) => new Vector2(x.Pos.x, x.Pos.z));
            int nPoints = pointsV2.Length;
            int VonoroiRes = voronoiGenerator.VonoroiRes;
            var VonoroiBuffer = new ComputeBuffer(pointsV2.Length, sizeof(float) * 2);
            VonoroiBuffer.SetData(pointsV2);
            
            var planes = planeMeshGenerator.planes;
            int dd = planeMeshGenerator.drawDistance * 2 + 1;
            voronoiMaps = new RenderTexture[dd, dd];
            int id = vonoroiMapShader.FindKernel("MapVonoroi");

            for (int x = 0; x < dd; x++)
            {
                for (int y = 0; y < dd; y++)
                {
                    voronoiMaps[x, y] = new RenderTexture(VonoroiRes, VonoroiRes, 24);
                    voronoiMaps[x, y].enableRandomWrite = true;
                    voronoiMaps[x, y].Create();
                    vonoroiMapShader.SetTexture(id, "Result", voronoiMaps[x, y]);
                    vonoroiMapShader.SetInt("nPoints", nPoints);
                    vonoroiMapShader.SetInt("VonoroiRes", VonoroiRes);

                    vonoroiMapShader.SetBuffer(id, "VonoroiBuffer", VonoroiBuffer);
                    vonoroiMapShader.Dispatch(id, VonoroiRes / 8, VonoroiRes / 8, 1);
                    planes[x, y].GetComponent<MeshRenderer>().sharedMaterial.mainTexture = voronoiMaps[x, y];
                    test = voronoiMaps[x, y];
                }
            }



        }
    }


}