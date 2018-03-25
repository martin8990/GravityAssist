
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class HexagonLevelGenerator : MonoBehaviourExt
    {
        public RegularHex HexPrefab;
       
        public int mapSize = 100;
        public int BaseHeight = 10;
        public Hexagon[,] map;
        public GameObject mapParent;
        public Vector2Int startPos;
        public float scaleMod;
        public float MultModY;
        public float offset;
        public Material mat;
        
        
        public void Start()
        {
            mat.color = ColorManager.DefaultColor;
        }


        [Button]
        public void GenerateMap()
        {
            mapParent.DestroyKids();
            map = new Hexagon[mapSize, mapSize];
            for (int x = 0; x < mapSize; x++)
            {
                for (int z = 0; z < mapSize; z++)
                {
                    if (x == startPos.x && z == startPos.y)
                    {
                        continue;
                    }
                    map[x, z] = Instantiate(HexPrefab, mapParent.transform);
                    if (z%2 == 0)
                    {
                        map[x, z].transform.position = new Vector3(x, BaseHeight, z * MultModY);
                    }
                    else
                    {
                        map[x, z].transform.position = new Vector3(x + 0.5f, BaseHeight, z * MultModY);
                    }
                    var scl = map[x, z].transform.localScale;
                    map[x, z].transform.localScale= new Vector3(scl.x* scaleMod, scl.y  *scaleMod, scl.z * BaseHeight);            
                    
                }
            }
         
         }


    }
    
}


