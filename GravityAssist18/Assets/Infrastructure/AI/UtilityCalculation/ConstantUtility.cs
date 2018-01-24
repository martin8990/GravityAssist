
using UnityEngine;

namespace Infrastructure
{
    
    public class ConstantUtility : UtilityCalculation
    {
        public float value;

        public override float CalculateUtility()
        {
            return value;
        }
    }

    

}


