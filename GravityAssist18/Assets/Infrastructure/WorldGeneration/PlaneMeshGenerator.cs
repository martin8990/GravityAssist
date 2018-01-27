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
        public float size;
        public int drawDistance;
        public int nNodes;
        public TerrainNode[,] terrainRaster;

 
        public int PlaneRes;
        [Button]
        public void GeneratePlanes()
        {

            if (planes1d!=null)
            {
                ArrayIter.Iter(planes1d, (x) => DestroyImmediate(x));
            }


            planes = WorldFactory.BuildPlanes(drawDistance, planePF, transform,size);
            planes1d = ArrayMap.Map2D1D(planes, (x) => x);
            PlaneRes = (int)Mathf.Sqrt(planes[0,0].GetComponent<MeshFilter>().sharedMesh.vertexCount);
            terrainRaster = WorldFactory.GenerateTerrainNodes(nNodes);            
        }

        public void OnDrawGizmos()
        {
            //if (terrainRaster!=null)
            //{
            //    Gizmos.color = Color.white;
            //    Action<int, int, TerrainNode>[] actions
            //        = { (x, y, TN) => Gizmos.DrawCube(new Vector3(x - nNodes / 2, 0, y - nNodes / 2), Vector3.one) };
            //    ArrayIter.Iteri2D<TerrainNode>(terrainRaster, actions);
            //}           
        }

    }

 



}
