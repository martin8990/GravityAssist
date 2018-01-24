
using UnityEngine;
using Utility;
using System.Collections.Generic;

namespace Infrastructure
{
    
    public class DistanceUtility : UtilityCalculation
    {
        public List<GameObject> targets;
        public override float CalculateUtility()
        {
            float minDist = Mathf.Infinity;
            foreach (var target in targets)
            {
                float dist = transform.position.AbsDist2(target.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                }
            }
            return minDist;
        }
    }
    

}


