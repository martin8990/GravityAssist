using UnityEngine;
using System.Collections.Generic;

namespace Utility
{
    public static class SquareDister
    {
        public static float SquareDist2(this Vector3 me, Vector3 dest)
        {
       

            return Mathf.Pow(dest.x - me.x, 2) + Mathf.Pow(dest.z  - me.z, 2);   
        }
        public static float AbsDist2(this Vector3 me, Vector3 dest)
        {
            return Mathf.Abs(dest.x - me.x) + Mathf.Abs(dest.z - me.z);
        }
        public static int GetNearestTargetId(this Vector3 position,List<Vector3> targets)
        {
            float mindist = Mathf.Infinity;
            int id = 0;
            for (int i = 0; i < targets.Count; i++)
            {
                var dist = position.SquareDist2(targets[i]);
                if (dist < mindist)
                {
                    mindist = dist;
                    id = i;
                }
            }
            return id;
        }
            
        

    }
}
