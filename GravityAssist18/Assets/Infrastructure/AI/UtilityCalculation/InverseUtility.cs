
using UnityEngine;

namespace Infrastructure
{

    public class InverseUtility : UtilityCalculation
    {
        public UtilityCalculation ChildCalculation;
        public override float CalculateUtility()
        {
            return 1f / ChildCalculation.CalculateUtility();
        }
    }

    

}


