using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Utility;
namespace Domain
{
    public static class WorldFactory
    {
        public static GameObject[,] BuildPlanes(int drawDist, GameObject planePF, Transform parent, float size)
        {
            var planes =
                ArrayInit.Init2D(
                drawDist * 2 + 1,
                drawDist * 2 + 1,
                () => GameObject.Instantiate(planePF)
                );
                Action<int, int, GameObject>[] iteries =
                { (x, y ,GO) => GO.transform.position =
                    new Vector3(x - drawDist,0,y-drawDist) * size};

            ArrayIter.Iter2D(planes, (x) => x.transform.localScale =
                x.transform.localScale * size / 2);
            ArrayIter.Iter2D(planes, (x) => 
                x.transform.SetParent(parent, false));

            ArrayIter.Iteri2D(planes, iteries);
            return planes;
        }

        public static TerrainNode[,] GenerateTerrainNodes(int nNodes)
        {
            TerrainNode[,] nodes = new TerrainNode[nNodes, nNodes];
            return nodes;
        }
    }
    public class TerrainNode
    {
        public float Height;
        public float Weight;
    }
}
