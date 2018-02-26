using System.Collections.Generic;
using UnityEngine;
using Utility;
namespace Infrastructure
{
    public class SmartBlock : MonoBehaviour
    {

        public List<SmartBlock> ChildBlocks = new List<SmartBlock>();
        public Vector3Int myMin
        {
            get { return (transform.position - transform.localScale / 2f).ToInt(); }
        }
        public Vector3Int myMax
        {
            get { return (transform.position + transform.localScale / 2f).ToInt(); }
        }
        public SmartBlock smartBlockPF;
        public int Priority;
        public Collider col;
        public int layer;
        public List<SmartBlock> slaves = new List<SmartBlock>();
        public MeshRenderer rend;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == layer)
            {
                var otherSmartBlock = other.gameObject.GetComponent<SmartBlock>();
                if (otherSmartBlock.Priority<=Priority)
                {
                    
                    slaves.Add(otherSmartBlock);
                    otherSmartBlock.Carve(myMin, myMax);
                }
            }
        }

        public void OnEdit()
        {
            UnCarve();
            slaves.Iter((x) => x.UnCarve());
        }

        public void UnCarve()
        {     
            ChildBlocks.Iter((x) => Destroy(x.gameObject));
            ChildBlocks = new List<SmartBlock>();
            //var s = myMax-myMin;
            //var p = new Vector3(myMax.x+myMin.x, myMax.y + myMin.y, myMax.z + myMin.z)/2f;
            //BuildBlock(p, s, "FrontMesh");
            col.enabled = true;
            rend.enabled = true;                       
        }           


        public void Carve(Vector3Int otherMin, Vector3Int otherMax)
        {
            col.enabled = false;
            rend.enabled = false;
            ChildBlocks.Iter((x) => Destroy(x.gameObject));
            ChildBlocks = new List<SmartBlock>();

            var p = Vector3.zero;
            var s = Vector3.zero;
            var ls = transform.localScale;

            float minY = Mathf.Max(myMin.y, otherMin.y);
            float maxY = Mathf.Min(myMax.y, otherMax.y);

            float minX = Mathf.Max(myMin.x, otherMin.x);
            float maxX = Mathf.Min(myMax.x, otherMax.x);

            if (myMin.x < otherMin.x && otherMin.x < myMax.x)
            {
                s = new Vector3((otherMin.x - myMin.x), (myMax.y - myMin.y), myMax.z - myMin.z);
                  p = new Vector3((myMin.x + otherMin.x), (myMax.y + myMin.y), myMin.z + myMax.z) / 2f;
             
                BuildBlock(p, s, "LeftMesh");
            }
            if (myMax.x > otherMax.x && otherMax.x > myMin.x)
            {
                s = new Vector3((myMax.x - otherMax.x), (myMax.y - myMin.y), myMax.z - myMin.z);
                p = new Vector3((myMax.x + otherMax.x), (myMax.y + myMin.y), myMin.z + myMax.z) / 2f;
               
                BuildBlock(p, s, "RightMesh");
            }
            if (myMin.y < otherMin.y && otherMin.y < myMax.y)
            {
                s = new Vector3(otherMax.x - otherMin.x, otherMin.y - myMin.y, myMax.z - myMin.z);
                p = new Vector3(otherMax.x + otherMin.x, otherMin.y + myMin.y, myMin.z + myMax.z) / 2f;
        
                BuildBlock(p, s,"DownMesh");
            }
            if (myMax.y > otherMax.y && otherMax.y > myMin.y)
            {
                s = new Vector3(maxX-minX, myMax.y-otherMax.y, myMax.z - myMin.z);
                p = new Vector3(maxX+minX, myMax.y + otherMax.y, myMin.z + myMax.z) / 2f;
                
                BuildBlock(p, s, "UpMesh");
            }
   
            if (myMin.z < otherMin.z && otherMin.z < myMax.z)
            {
              
                s = new Vector3(maxX - minX, minY - maxY, otherMin.z - myMin.z);
                p = new Vector3(maxX + minX, minY+maxY, otherMin.z + myMin.z) / 2f;
                BuildBlock(p, s, "BackMesh");
            }
            if (myMax.z > otherMax.z && otherMax.z > myMin.z)
            {

                s = new Vector3(maxX - minX, minY - maxY, myMax.z - otherMax.z);
                p = new Vector3(maxX + minX, minY + maxY, myMax.z + otherMax.z) / 2f;
           
                BuildBlock(p, s, "FrontMesh"); 
            }
        }

        void BuildBlock(Vector3 p, Vector3 s,string name)
        {
            var GO = Instantiate(smartBlockPF, transform.parent);
            GO.transform.position = p;
            GO.transform.localScale = s;
            GO.name = name;
            GO.rend.enabled = true;
            GO.col.enabled = true;
            ChildBlocks.Add(GO);
        }
    }

}
