using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Infrastructure
{

    public class AIUnit : MonoBehaviour
    {
        Tactic prevTactic;
        public List<Strategy> strategies;

        public void Trigger(int period)
        {
            var bestStrategy = strategies.Min((x) => x.GetStrategyUtility());
            bestStrategy.ExecuteBestTactic(period);
        }        
    }


}


