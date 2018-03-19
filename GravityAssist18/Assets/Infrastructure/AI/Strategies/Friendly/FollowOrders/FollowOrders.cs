using System.Collections.Generic;

namespace Infrastructure
{
    public class FollowOrders : Strategy
    {
 
        public override float GetStrategyUtility()
        {
            if (tactics.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }





}


