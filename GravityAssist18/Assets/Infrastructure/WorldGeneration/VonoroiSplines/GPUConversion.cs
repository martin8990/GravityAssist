using UnityEngine;
using System.Linq;
using Utility;
using Domain;
using System.Collections.Generic;

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
            AddContinuityAngles(Samples);

            for (int i = 0; i < tPoints.Count; i++)
            {
                GPUterrainPoints[i] = new GPUTerrainPoint(tPoints[i].Pos, tPoints[i].Neighbours.Count + 2, StartingId);
                StartingId += (tPoints[i].Neighbours.Count + 2) * RadiiPerAngle;
            }
            terrainSamples = new TerrainSample[StartingId];
            ConvertToGpuSamples(Samples);

        }

        private void ConvertToGpuSamples(List<List<List<Polar3>>> Samples)
        {
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

        private void AddContinuityAngles(List<List<List<Polar3>>> Samples)
        {
            List<Polar3> underSamples = new List<Polar3>();
            List<Polar3> overSamples = new List<Polar3>();

            for (int i = 0; i < Samples.Count; i++)
            {
                for (int k = 0; k < RadiiPerAngle; k++)
                {
                    var CurAngles = new List<float>();
                    var CurSamples = new List<Polar3>();
                    for (int j = 0; j < Samples[i].Count; j++)
                    {

                        if (k < Samples[i][j].Count)
                        {
                            CurAngles.Add(Samples[i][j][k].phi);
                            CurSamples.Add(Samples[i][j][k]);

                        }
                    }
                    if (CurAngles.Count > 0)
                    {
                        int mindex = CurAngles.ListMin();
                        int maxdex = CurAngles.ListMax();

                        var minSamp = CurSamples[mindex];
                        minSamp = new Polar3(minSamp.r, minSamp.h, minSamp.phi + 2f * Mathf.PI);

                        var maxSamp = CurSamples[maxdex];
                        maxSamp = new Polar3(maxSamp.r, maxSamp.h, maxSamp.phi - 2f * Mathf.PI);
                        underSamples.Add(minSamp);
                        overSamples.Add(maxSamp);

                    }
                }
                Samples[i].Add(underSamples);
                Samples[i].Add(overSamples);


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