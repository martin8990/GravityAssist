using UnityEngine;
using System.Linq;
using Utility;
using Domain;
namespace Infrastructure
{
    public class GPUConversion : MonoBehaviour
    {
        public VonoroiGenerator vonoroiGenerator;
        public Heightmapper heightmapper;
        public GPUTerrainPoint[] GPUterrainPoints;
        public TerrainSample[] terrainSamples;
        public int RadiiPerAngle;

        [Button]
        public void PrepareForGPU()
        {
            var Samples = heightmapper.Samples;
            var tPoints = vonoroiGenerator.terrainPoints;
            int StartingId = 0;
            GPUterrainPoints = new GPUTerrainPoint[Samples.Count];

            for (int i = 0; i < Samples.Count; i++)
            {
                for (int k = 0; k < RadiiPerAngle; k++)
                {
                    for (int j = 0; j < Samples[i].Count; j++)
                    {
                        if (k < Samples[i][j].Count)
                        {
                            
                        }
                    }
                }
            }


            for (int i = 0; i < tPoints.Count; i++)
            {
                GPUterrainPoints[i] = new GPUTerrainPoint(tPoints[i].Pos, tPoints[i].Neighbours.Count + 2, StartingId);
                StartingId += (tPoints[i].Neighbours.Count + 2) * RadiiPerAngle;
            }
            terrainSamples = new TerrainSample[StartingId];
            int counter = 0;




            for (int i = 0; i < Samples.Count; i++)
            {
                for (int j = 0; j < Samples[i].Count; j++)
                {
                    for (int k = 0; k < RadiiPerAngle; k++)
                    {
                        if (k < Samples[i][j].Count)
                        {
                            var samp = Samples[i][j][k];
                            terrainSamples[counter] = new TerrainSample(samp.h, samp.phi);

                        }
                        else
                        {
                            terrainSamples[counter] = new TerrainSample(0, 0);
                        }

                        counter++;

                    }
                }
            }

        }

        public void SendToGPU()
        {

        }

        public void OnDrawGizmosSelected()
        {
            float radiusUnit = heightmapper.maxRadius / heightmapper.nRadii;

            Gizmos.color = Color.blue;

            for (int i = 0; i < GPUterrainPoints.Length; i++)
            {
                for (int j = 0; j < GPUterrainPoints[i].NNeighbours; j++)
                {
                    for (int k = 0; k < RadiiPerAngle; k++)
                    {
                        var samp = terrainSamples[GPUterrainPoints[i].StartingIndex + j * RadiiPerAngle + k];
                        var v3 = new Polar3(k * radiusUnit, samp.Height, samp.Angle).toCart() + new Vector3(GPUterrainPoints[i].Pos.x, 0, GPUterrainPoints[i].Pos.z);

                        var v2 = vonoroiGenerator.VonoroitoWorldPos(new Vector2(v3.x, v3.z));
                        float h = v3.y * 20f;
                        v3 = new Vector3(v2.x, h, v2.y);
                        Gizmos.DrawCube(v3, Vector3.one * 0.5f);
                    }
                }
            }

        }


    }


}