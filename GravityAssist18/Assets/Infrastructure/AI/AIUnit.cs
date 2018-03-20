using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Infrastructure
{

    public class AIUnit : MonoBehaviour
    {
        public List<Strategy> strategies = new List<Strategy>();
        

        public virtual void Trigger(int period)
        {

            var bestStrategy = strategies.Max((x) => x.GetStrategyUtility());
        
            bestStrategy.ExecuteBestTactic(period);
        }        
    }

    

}


