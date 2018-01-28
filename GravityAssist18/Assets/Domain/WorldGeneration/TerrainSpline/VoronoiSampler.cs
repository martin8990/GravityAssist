using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csDelaunay;
using Utility;
using UnityEngine;
namespace Domain
{
    public static class VoronoiSampler
    {


       

        public static List<List<List<Polar3>>> SampleVoronoiSplines(
            List<TerrainPoint> terrainPoints,
            int SampFreq,
            int nRadii,
            float maxRadius
            )
        {
            float radiusUnit = maxRadius / nRadii;
            var samples = new List<List<List<Polar3>>>();
            Debug.Log(radiusUnit);
            List<List<Polar3>> mySamps = new List<List<Polar3>>();

            for (int i = 0; i < terrainPoints.Count; i++)
            {
                // var mySamps = new List<List<Polar3>>();

                var neighBours = terrainPoints[i].Neighbours;
                mySamps = new List<List<Polar3>>();
                
                for (int N = 0; N < neighBours.Count; N++)
                {
                    var p0 = terrainPoints[i].Pos;
                    var p1 = neighBours[N].SplineCTRLLookup[terrainPoints[i]];
                    var p2 = terrainPoints[i].SplineCTRLLookup[neighBours[N]];
                    var p3 = neighBours[N].Pos;

                    var CTRLIN = new Polar3(new Vector3(p1.x-p0.x,p1.y,p1.z-p0.z));
                    var CTRLOUT = new Polar3(new Vector3(p2.x - p0.x, p2.y, p2.z - p0.z)); 
                    var Dest = new Polar3(new Vector3(p3.x - p0.x, p3.y, p3.z - p0.z));

                    Polar3 startPos = new Polar3(0, terrainPoints[i].Pos.y, Dest.phi);
                    var toNeighbourSamps = new List<Polar3>();
                    int counter = 1;
                    var prevPos = startPos;
                    for (int k = 0; k < SampFreq; k++)
                    {
                        Polar3 pos = Polar3.SplineCalc(k / (float)SampFreq, new Polar3[] { startPos, CTRLOUT, CTRLIN, Dest});

                        if (pos.r > counter * radiusUnit)
                        {
                            var sample = Polar3.rTAprox(prevPos, pos, pos.r);
                            toNeighbourSamps.Add(sample);
                            counter += 1;
                        }
                        prevPos = pos;

                    }
                    mySamps.Add(toNeighbourSamps);

                }

                samples.Add(mySamps);
            }
            return samples;
            //return samples;
            //return destPolars3;
        }

        public static List<List<List<Polar3>>> SampleVoronoiLerp(
            Site[] sites,
            int SampFreq,
            int nRadii,
            float maxRadius)
        {
            float radiusUnit = maxRadius / nRadii;
            var samples = new List<List<List<Polar3>>>();
            List<Polar3> destPolars3 = new List<Polar3>();
            List<List<Polar3>> mySamps = new List<List<Polar3>>();

            for (int i = 0; i < sites.Length; i++)
            {
                // var mySamps = new List<List<Polar3>>();

                var neighBours = sites[i].NeighborSites();

                var dp = ListMap.Map(neighBours, (x) => new Polar2(x.Coord - sites[i].Coord));
                destPolars3 = ListMap.Map2(dp, neighBours, (x, y) => new Polar3(x.r, y.Heigth, x.phi));

                mySamps = new List<List<Polar3>>();
                for (int N = 0; N < destPolars3.Count; N++)
                {
                    Polar3 startPos = new Polar3(0, sites[i].Heigth, destPolars3[N].phi);
                    var toNeighbourSamps = new List<Polar3>();
                    int counter = 1;
                    var prevPos = startPos;
                    for (int k = 0; k < SampFreq; k++)
                    {
                        Polar3 pos = Polar3.Lerp(startPos, destPolars3[N], k / (float)SampFreq);

                        if (pos.r > counter * radiusUnit)
                        {
                            var sample = Polar3.rTAprox(prevPos, pos, pos.r);
                            toNeighbourSamps.Add(sample);
                            counter += 1;
                        }
                        prevPos = pos;

                    }
                    mySamps.Add(toNeighbourSamps);

                }

                samples.Add(mySamps);
            }
            return samples;
            //return samples;
            //return destPolars3;
        }
    }

    
}
