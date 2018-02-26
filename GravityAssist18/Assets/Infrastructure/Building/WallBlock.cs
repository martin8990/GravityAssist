using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{


    public class WallBlock : Block
    {
        public float MyHeight = 10f;
        public BuildColors buildColors;
        public WallNode wallPrefab;
        public LayerMask foundationLayer;
        public LayerMask WallLayer;
        public CV3IntHashSet V3HashSet; 

        Material mat;
        List<GameObject> RemovedWalls = new List<GameObject>();
        List<WallNode> myWalls = new List<WallNode>();

        private void Start()
        {
            mat = GetComponent<MeshRenderer>().material;
        }

        public override void TransformBlock(Vector3 p1, Vector3 p2)
        {
            int x0 = Mathf.FloorToInt(Mathf.Min(p1.x, p2.x));
            int x1 = Mathf.CeilToInt(Mathf.Max(p1.x, p2.x));
            int z0 = Mathf.FloorToInt(Mathf.Min(p1.z, p2.z));
            int z1 = Mathf.CeilToInt(Mathf.Max(p1.z, p2.z));

            if (x1 - x0 > z1 - z0)
            {
                z1 = z0 + 1;
            }
            else
            {
                x1 = x0 + 1;
            }

            cost = 0;
            valid = true;
            mat.color = buildColors.PlanColor;
            float height = 0;

            RemovedWalls.Iter((x) => x.SetActive(true));
            RemovedWalls = new List<GameObject>();

            this.DestroyKids();

            myWalls = new List<WallNode>();

            for (int x = x0; x < x1; x++)
            {
                for (int z = z0; z < z1; z++)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(new Vector3(x + 0.5f, 100, z + 0.5f), Vector3.down, out hit, 100, foundationLayer))
                    {
                        height = hit.point.y;                      
                        cost += Mathf.Max(0, MyHeight - height);
                        if (Physics.Raycast(new Vector3(x + 0.5f, 100, z + 0.5f), Vector3.down, out hit, 100, WallLayer))
                        {
                            var wall = hit.collider.gameObject;
                            RemovedWalls.Add(wall);
                            V3HashSet.hashSet.Remove(wall.transform.position.ToInt());
                            wall.SetActive(false);
                        }

                        var myWall = Instantiate(wallPrefab,transform);
                        
                        myWall.transform.position = new Vector3(x+0.50000f, MyHeight / 2f + height, z + 0.5000000f);
                        V3HashSet.hashSet.Add(myWall.transform.position.ToInt());
                        myWall.transform.localScale = new Vector3(1, MyHeight , 1);
                        myWalls.Add(myWall);
                    }
                    else
                    {
                        valid = false;
                        mat.color = buildColors.InvalidColor;
                    }
                }
            }
            
      //      var scale = new Vector3(Mathf.Abs(x1-x0) , MyHeight, Mathf.Abs(z1 - z0) );
      //      transform.localScale = scale;
     //       transform.position = new Vector3(x0 + (x1 - x0)/ 2f, MyHeight / 2f + height, z0 + (z1 - z0) / 2f);

        }

        public override void CompleteBlock()
        {
            gameObject.layer = WallLayer;
        }
    }
        
}
