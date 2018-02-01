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
            var pointsV3 = ArrayMap.Map(terrainPoints, (x) => x.Pos);
            int nPoints = pointsV3.Length;
            int VonoroiRes = voronoiGenerator.VonoroiRes;
            var VonoroiBuffer = new ComputeBuffer(pointsV3.Length, sizeof(float) * 3);
            VonoroiBuffer.SetData(pointsV3);
            
            var planes = planeMeshGenerator.planes;
            int dd = planeMeshGenerator.drawDistance * 2 + 1;
            voronoiMaps = new RenderTexture[dd, dd];
            int id = vonoroiMapShader.FindKernel("MapVonoroi3");

            for (int x = 0; x < dd; x++)
            {
                for (int y = 0; y < dd; y++)
                {
                    voronoiMaps[x, y] = new RenderTexture(VonoroiRes/dd, VonoroiRes/dd, 24);
                    voronoiMaps[x, y].enableRandomWrite = true;
                    voronoiMaps[x, y].Create();
                    vonoroiMapShader.SetTexture(id, "Result", voronoiMaps[x, y]);
                    vonoroiMapShader.SetInt("nPoints", nPoints);
                    vonoroiMapShader.SetInt("VonoroiRes", VonoroiRes);
                    vonoroiMapShader.SetInt("CoordX", dd-x-1);
                    vonoroiMapShader.SetInt("CoordY", y);
                    vonoroiMapShader.SetInt("Resolution", VonoroiRes/dd);



                    vonoroiMapShader.SetBuffer(id, "VonoroiBuffer", VonoroiBuffer);
                    vonoroiMapShader.Dispatch(id, VonoroiRes / 8, VonoroiRes / 8, 1);
                    planes[x, y].GetComponent<MeshRenderer>().material.SetTexture("mainTex", voronoiMaps[x, y]);
                    test = voronoiMaps[x, y];
                }
            }



        }
    }


}