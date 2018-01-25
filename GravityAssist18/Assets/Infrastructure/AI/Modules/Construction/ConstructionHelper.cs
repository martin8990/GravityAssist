using UnityEngine;
using Utility;
using System.Collections.Generic;
namespace Infrastructure
{
    public static class ConstructionHelper
    {

        

        public static Vector3 GetClosestWorkSpace(Transform square, Vector3 myPos)
        {
            var WorkScale = square.localScale;
            var WorkPos = square.position;

            if (WorkScale.x > WorkScale.z)
            {
                var p1 = WorkPos + new Vector3(0, 0, WorkScale.z / 2);
                var p2 = WorkPos - new Vector3(0, 0, WorkScale.z / 2);

                if (myPos.SquareDist2(p1) < myPos.SquareDist2(p2))
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
            else
            {
                var p1 = WorkPos + new Vector3(WorkScale.x / 2, 0, 0);
                var p2 = WorkPos - new Vector3(WorkScale.x / 2, 0, 0);
                if (myPos.SquareDist2(p1) < myPos.SquareDist2(p2))
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
        }

       
    }



}


