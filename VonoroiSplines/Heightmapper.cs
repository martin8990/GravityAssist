using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Domain;
using Utility;
using csDelaunay;
namespace Infrastructure
{
    public class Heightmapper : MonoBehaviour
    {
        public VonoroiGenerator vonoroiGenerator;

        public int nRadii = 100;
        public float maxRadius = 20;
        public int nAngles = 20; 
        public int SampleFreq = 100;
        public float[,,] HeightSamples;
        public List<List<List<Polar3>>> Samples = new List<List<List<Polar3>>>();
        List<List<Polar3>> mySamps;
        List<TerrainPoint> terrainPoints;
         

        
        [Button]
        public void SampleVonoroi()
        {
           
            terrainPoints = vonoroiGenerator.terrainPoints;
            Samples = new List<List<List<Polar3>>>();
            Samples = VoronoiSampler.SampleVoronoiSplines(terrainPoints, SampleFreq, nRadii, maxRadius);
            


        }

        public void OnDrawGizmosSelected()
        {

            Gizmos.color = Color.blue;
            
            for (int i = 0; i < Samples.Count; i++)
            {
                for (int j = 0; j < Samples[i].Count; j++)
                {
                    for (int k = 0; k < Samples[i][j].Count; k++)
                    {
                        var v3 = Samples[i][j][k].toCart() +new Vector3(terrainPoints[i].Pos.x,0, terrainPoints[i].Pos.z);
                            
                        var v2 = vonoroiGenerator.VonoroitoWorldPos(new Vector2(v3.x,v3.z));
                        float h =  v3.y * 20f;
                        v3 = new Vector3(v2.x, h, v2.y);
                        Gizmos.DrawCube(v3, Vector3.one * 0.5f);
                    }
                }
            }
        }
    }


}