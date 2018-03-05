//using System.Collections.Generic;
//using UnityEngine;
//using Utility;

//namespace Infrastructure
//{
//    public class FoundationBlock : Block
//    {
//        public HeightMap heightMap;
//        public float MyHeight = 10f;
//        public BuildColors buildColors;
//        public CInt FoundationLayer;
//        Material mat;
//        public List<GameObject> MergeBlocks = new List<GameObject>();

//        void OnTriggerEnter(Collider other)
//        {
//            int layer = other.gameObject.layer;
//            if (FoundationLayer ==  layer)
//            {
//                MergeBlocks.Add(other.gameObject);
//            }
//        }
//        void OnTriggerExit(Collider other)
//        {
//            int layer = other.gameObject.layer;
//            if (FoundationLayer == layer)
//            {
//                MergeBlocks.Remove(other.gameObject);
//            }
//}

//        private void Start()
//        {
//            mat = GetComponent<MeshRenderer>().material;
//        }

//        public override void TransformBlock(Vector3 p1, Vector3 p2)
//        {
//            if (Input.GetKeyDown(KeyCode.LeftShift))
//            {
//                MyHeight++;
//            }
//            if (Input.GetKeyDown(KeyCode.LeftControl))
//            {
//                MyHeight--;
//            }

//            int x0 = Mathf.FloorToInt(Mathf.Min(p1.x, p2.x));
//            int x1 = Mathf.CeilToInt(Mathf.Max(p1.x, p2.x));
//            int z0 = Mathf.FloorToInt(Mathf.Min(p1.z, p2.z));
//            int z1 = Mathf.CeilToInt(Mathf.Max(p1.z, p2.z));

//            List<Vector2Int> Mins = new List<Vector2Int>();
//            List<Vector2Int> Maxs = new List<Vector2Int>();
//            List<float> heights = new List<float>();

//            for (int i = 0; i < MergeBlocks.Count; i++)
//            {
//                var p = MergeBlocks[i].transform.position;
//                var s = MergeBlocks[i].transform.localScale;

//                var min = new Vector2Int((int)(p.x - s.x / 2) - 1, (int)(p.z - s.z / 2) -1);
//                var max = new Vector2Int((int)(p.x + s.x / 2), (int)(p.z + s.z / 2));
//                var height = p.y + s.y / 2;

//                Mins.Add(min);
//                Maxs.Add(max);
//                heights.Add(height);
//            }

//            cost = 0;
//            valid = true;
            
//            mat.color = buildColors.PlanColor;
//            for (int x = x0; x < x1; x++)
//            {
//                for (int z = z0; z < z1; z++)
//                {
//                    float height = heightMap.heightMap[x,z];
//                    for (int i = 0; i < MergeBlocks.Count; i++)
//                    {
//                        if (x > Mins[i].x && x < Maxs[i].x && z > Mins[i].y && z < Maxs[i].y)
//                        {
//                            height = Mathf.Max(height, heights[i]);
//                        }
//                    }
//                    if (height > MyHeight)
//                    {
//                        valid = false;
//                        mat.color = buildColors.InvalidColor;
                      
//                    }
//                    cost += Mathf.Max(0,MyHeight - height);
//                }
//            }
            
                     
//            var scale = new Vector3(Mathf.Abs(p2.x - p1.x) + 1, MyHeight, Mathf.Abs(p2.z - p1.z) + 1);
//            transform.localScale = scale;
//            transform.position = new Vector3(p1.x + (p2.x - p1.x) / 2f, MyHeight / 2f, p1.z + (p2.z - p1.z) / 2f);

//        }

//        public override void CompleteBlock()
//        {
//            gameObject.layer = FoundationLayer;
//        }
//    }
//}
