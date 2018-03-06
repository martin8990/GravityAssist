using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utility;
namespace Infrastructure
{
    public class CarveLogic : MonoBehaviour
    {
        List<CarvableBlock> ChildBlocks = new List<CarvableBlock>();
        Vector3Int myMin
        {
            get { return (transform.position - transform.localScale / 2f).ToInt(); }
        }
        Vector3Int myMax
        {
            get { return (transform.position + transform.localScale / 2f).ToInt(); }
        }
        [HideInInspector]
        public Action<Vector3, Vector3,string> OnBuildBlock;



        public void GetCarved(Vector3Int otherMin, Vector3Int otherMax)
        {

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
             
                OnBuildBlock.Invoke(p, s, "LeftMesh");
            }
            if (myMax.x > otherMax.x && otherMax.x > myMin.x)
            {
                s = new Vector3((myMax.x - otherMax.x), (myMax.y - myMin.y), myMax.z - myMin.z);
                p = new Vector3((myMax.x + otherMax.x), (myMax.y + myMin.y), myMin.z + myMax.z) / 2f;

                OnBuildBlock.Invoke(p, s, "RightMesh");
            }
            if (myMin.y < otherMin.y && otherMin.y < myMax.y)
            {
                s = new Vector3(otherMax.x - otherMin.x, otherMin.y - myMin.y, myMax.z - myMin.z);
                p = new Vector3(otherMax.x + otherMin.x, otherMin.y + myMin.y, myMin.z + myMax.z) / 2f;

                OnBuildBlock.Invoke(p, s,"DownMesh");
            }
            if (myMax.y > otherMax.y && otherMax.y > myMin.y)
            {
                s = new Vector3(maxX-minX, myMax.y-otherMax.y, myMax.z - myMin.z);
                p = new Vector3(maxX+minX, myMax.y + otherMax.y, myMin.z + myMax.z) / 2f;

                OnBuildBlock.Invoke(p, s, "UpMesh");
            }
   
            if (myMin.z < otherMin.z && otherMin.z < myMax.z)
            {
              
                s = new Vector3(maxX - minX, maxY - minY, otherMin.z - myMin.z);
                p = new Vector3(maxX + minX, minY+maxY, otherMin.z + myMin.z) / 2f;
                OnBuildBlock.Invoke(p, s, "BackMesh");
            }
            if (myMax.z > otherMax.z && otherMax.z > myMin.z)
            {

                s = new Vector3(maxX - minX, maxY - minY, myMax.z - otherMax.z);
                p = new Vector3(maxX + minX, minY + maxY, myMax.z + otherMax.z) / 2f;

                OnBuildBlock.Invoke(p, s, "FrontMesh"); 
            }
        }

    }

}
