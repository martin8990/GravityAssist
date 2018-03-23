
//using System.Collections.Generic;
//using UnityEngine;
//using Utility;

//namespace Infrastructure
//{
//    public class CubeLevelGenerator : MonoBehaviourExt
//    {
//        public LevelCube CubePrefab;
//        public int mapSize = 100;
//        public int BaseHeight = 10;
//        public LevelCube[,] map;
//        public float dungHeight;
//        public List<Dungeon> dungeons;
//        public List<Connection> connections;
//        public GameObject mapParent;

//        [Button]
//        public void GenerateMap()
//        {
//            mapParent.DestroyKids();
//            map = new LevelCube[mapSize, mapSize];
//            for (int x = 0; x < mapSize; x++)
//            {
//                for (int z = 0; z < mapSize; z++)
//                {
//                    map[x, z] = Instantiate(CubePrefab,mapParent.transform);
//                    map[x, z].transform.position = new Vector3(x, BaseHeight/2f, z);
//                    map[x, z].transform.localScale = new Vector3(1, BaseHeight, 1);               
//                }
//            }
//            for (int i = 0; i < dungeons.Count; i++)
//            {
//                var dung = dungeons[i];
//                for (int x = -dung.size; x < dung.size; x++)
//                {
//                    for (int z = -dung.size; z < dung.size; z++)
//                    {
//                        var cube = map[dung.Position.x + x, dung.Position.y + z];
//                        var prevPos = cube.transform.position;
//                        cube.transform.position = new Vector3(prevPos.x, dungHeight / 2f, prevPos.z);
//                        cube.transform.localScale = new Vector3(1, dungHeight ,1);

//                    }
//                }
//            }
//            for (int i = 0; i < connections.Count; i++)
//            {
//                var p1 = connections[i].D1.Position;
//                var p2 = connections[i].D2.Position;

//                int dx = Mathf.Abs(p2.x - p1.x);
//                int dz = Mathf.Abs(p2.y - p1.y);
//                if (dx>dz)
//                {
//                    dz = p2.y - p1.y;
//                    for (int x = 0; x < dx; x++)
//                    {
                        
//                        for (int ddz = -connections[i].Width; ddz < connections[i].Width; ddz++)
//                        {
//                            int z = (int)(dz / (float)dx * x + ddz);
//                            var go = map[x + Mathf.Min(p1.x, p2.x), z  + p1.y];
//                            go.transform.localScale = new Vector3(1, dungHeight, 1);
//                            var prevPos = go.transform.position;
//                            go.transform.position = new Vector3(prevPos.x, dungHeight / 2f, prevPos.z);
//                        }
                        
//                    }
//                }
//                else
//                {
//                    dx = p2.x - p1.x;
//                    for (int z = 0; z < dz; z++)
//                    {
//                        for (int ddx = -connections[i].Width; ddx < connections[i].Width; ddx++)
//                        {
//                            int x = (int)(dx /(float)dz * z + ddx);
//                            var go = map[x + p1.x, z + Mathf.Min(p1.y, p2.y)];
//                            go.transform.localScale = new Vector3(1, dungHeight, 1);
//                            var prevPos = go.transform.position;
//                            go.transform.position = new Vector3(prevPos.x, dungHeight / 2f, prevPos.z);

//                        }
//                    }
//                }


//            }
//        }

//    }
//    [System.Serializable]
//    public class Connection
//    {
//        public Dungeon D1;
//        public Dungeon D2;
//        public int Width;
        
//    }
//}


