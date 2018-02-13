using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using UnityEngine;
using Utility;
using System.Collections.Generic;

namespace Infrastructure
{
    public class PlaneMeshGenerator : MonoBehaviour
    {
        public GameObject[,] planes;
        public GameObject[] planes1d;
        public GameObject planePF;
        public CFloat size;
        public CInt drawDistance;
        public TerrainNode[,] terrainRaster;

        private void Start()
        {
            GeneratePlanes();
        }

        public int PlaneRes;
        [Button]
        public void GeneratePlanes()
        {

            if (planes1d != null)
            {
                ArrayIter.Iter(planes1d, (x) => DestroyImmediate(x));
            }
            planes = WorldFactory.BuildPlanes(drawDistance, planePF, transform, size);
            planes1d = ArrayMap.Map2D1D(planes, (x) => x);
            PlaneRes = (int)Mathf.Sqrt(planes[0, 0].GetComponent<MeshFilter>().sharedMesh.vertexCount);
        }
    }





}
