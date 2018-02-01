using UnityEngine;
using System.Collections.Generic;
using Domain;
using csDelaunay;
using Utility;
using System.Linq;
namespace Infrastructure
{

    public class VonoroiGenerator : MonoBehaviour
    {

        public int NPoints = 20;
        
        public Dictionary<Vector2f, Site> sites;
        public List<TerrainPoint> terrainPoints = new List<TerrainPoint>();

        public GameObject VoronoiMarker;
        public PlaneMeshGenerator planeMeshGenerator;
     
        public List<GameObject> markers = new List<GameObject>();
        public int VonoroiRes = 256;
        public float distMod = 1/256f;

        public int BeachDist;
        public int BeachRandomAmp;


        [Button]
        public void GenerateVoronoi()
        {
            terrainPoints = new List<TerrainPoint>();
            markers.IterR((x) => DestroyImmediate(x));
            markers.Clear();
            

            List<Vector2f> points = CreateRandomPoint(VonoroiRes);
            Rectf bounds = new Rectf(0, 0, VonoroiRes, VonoroiRes);
            Voronoi voronoi = new Voronoi(points, bounds, 5);

            sites = voronoi.SitesIndexedByLocation;

            foreach (var site in sites.Keys)
            {
                var tPoint = new TerrainPoint();
                var dist = Vector2.Distance(new Vector2(site.x, site.y), Vector2.one * 0.5f * VonoroiRes);
                float Height = 0.5f;
                if (dist + Mathf.PerlinNoise(site.x,site.y)* BeachRandomAmp > BeachDist)
                {
                    Height = 0;
                }
                tPoint.Pos = new Vector3(site.x, Height, site.y);
                tPoint.TerrainVal = new TerrainValue(0, 1, Color.green,tPoint.Pos.y);
                terrainPoints.Add(tPoint);

                var mark = GameObject.Instantiate(VoronoiMarker);
                mark.transform.SetParent(this.transform, false);
                mark.transform.position = new Vector3(-(site.x - 0.5f* VonoroiRes), tPoint.Pos.y * 100f, site.y - 0.5f* VonoroiRes)/VonoroiRes*((2*planeMeshGenerator.drawDistance + 1) * planeMeshGenerator.size);
                markers.Add(mark);
            }
            var sitesArr = sites.Values.ToArray();

            for (int i = 0; i < sitesArr.Length; i++)
            {
                var neighbourSites = sitesArr[i].NeighborSites();
                foreach (var neighbour in neighbourSites)
                {
                    var tPoint = terrainPoints[i];
                    var terrainNeighbour = terrainPoints.Where((x) => x.Pos.x == neighbour.Coord.x && x.Pos.z == neighbour.Coord.y).Single();
                    if (terrainNeighbour != null)
                    {
                        tPoint.Neighbours.Add(terrainNeighbour);
                        tPoint.SplineCTRLLookup.Add(terrainNeighbour,(tPoint.Pos + terrainNeighbour.Pos)/2f );
                    }
                    else
                    {
                        Debug.Log("BUG!");
                    }
                }

            }

        }

        public Vector2 VonoroitoWorldPos(Vector2 vonoroiPos)
        {
           return new Vector2(-(vonoroiPos.x - 0.5f * VonoroiRes), vonoroiPos.y - 0.5f * VonoroiRes) /
                VonoroiRes * ((2 * planeMeshGenerator.drawDistance + 1) * planeMeshGenerator.size);
        }

        private List<Vector2f> CreateRandomPoint(int PlaneRes)
        {
            List<Vector2f> points = new List<Vector2f>();
            for (int i = 0; i < NPoints; i++)
            {
                points.Add(new Vector2f(Random.Range(0, PlaneRes), Random.Range(0, PlaneRes)));
            }

            return points;
        }
        
    }


}