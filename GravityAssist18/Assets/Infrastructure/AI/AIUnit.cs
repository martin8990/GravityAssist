using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Infrastructure
{

    public class AIUnit : MonoBehaviour
    {
        public List<Strategy> strategies = new List<Strategy>();
        bool busy;
        
        public virtual IEnumerator Trigger(int period)
        {
            if (!busy)
            {
                busy = true;
                var bestStrategy = strategies.Max((x) => x.GetStrategyUtility());
                yield return StartCoroutine(bestStrategy.ExecuteBestTactic(period));
                busy = false;
            }
            else
            {
                yield return null;
            }
        }        
    }

    

}


