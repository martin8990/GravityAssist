
using System.Collections.Generic;
using System.Linq;
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

        public float scaleMod;
        public float scaleMod2;
        public float MultModY;
        public float offset;
        public float SpawnOffsetRatio = 0.2f;
        public int SpawnSize = 4;

        public Material mat;
        public PerlinLayer emptyLayer;
        HashSet<Vector2Int> spawnCoords;
        public List<Vector2Int> SpawnCoordsList = new List<Vector2Int>();
        public static List<Vector3> SpawnPositions;

        public void Awake()
        {
            SpawnPositions = SpawnCoordsList.Map((coord) => GetPos(coord.x, coord.y) - Vector3.down *BaseHeight);
            mat.color = ColorManager.DefaultColor;
        }


        [Button]
        public void GenerateMap()
        {
            mapParent.DestroyKids();
            map = new Hexagon[mapSize, mapSize];

            var spawnOffset = mapSize * SpawnOffsetRatio;
            var startCoord = new Vector2Int((int)Random.Range(spawnOffset, mapSize - spawnOffset), (int)Random.Range(spawnOffset, mapSize - spawnOffset));
            Debug.Log(startCoord);
            spawnCoords = new HashSet<Vector2Int>();
            for (int x = -SpawnSize; x < SpawnSize; x++)
            {
                for (int z = -SpawnSize; z < SpawnSize; z++)
                {
                    var coord = new Vector2Int(x + startCoord.x, z + startCoord.y);
                    spawnCoords.Add(coord);
               
                }
            }

            for (int x = 0; x < mapSize; x++)
            {
                for (int z = 0; z < mapSize; z++)
                {
                    if (!spawnCoords.Contains(new Vector2Int(x, z)))
                    {
                        if (x != 0 && x != mapSize - 1 && z != 0 && z != mapSize - 1 && emptyLayer.inLayer(x, z))
                        {
                            map[x, z] = null;
                            //spawnCoords.Add(new Vector2Int(x, z));
                        }
                        else
                        {
                            map[x, z] = Instantiate(HexPrefab, mapParent.transform);
                            map[x, z].transform.position = GetPos(x, z);
                            var scl = map[x, z].transform.localScale;
                            map[x, z].transform.localScale = new Vector3(scl.x * scaleMod, scl.y * scaleMod, scl.z * BaseHeight) * scaleMod2;
                        }
                    }
                }
            }
            SpawnCoordsList = spawnCoords.ToList();







        }

        public Vector3 GetPos(int x, int z)
        {
            if (z % 2 == 0)
            {
                return new Vector3(x, BaseHeight, z * MultModY) * scaleMod2;
            }
            else
            {
                return new Vector3(x + 0.5f, BaseHeight, z * MultModY) * scaleMod2;
            }
        }


    }

}


