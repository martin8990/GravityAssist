using System.Collections.Generic;

using UnityEngine;
using Utility;

namespace Infrastructure
{
    public abstract class Strategy : MonoBehaviour
    {
        public List<Tactic> tactics = new List<Tactic>();
        public abstract float GetStrategyUtility();
        public void ExecuteBestTactic(int period)
        {
           var bestTactic = tactics.Max((x) => x.CalculateUtility());
            if (bestTactic!=null)
            {
                StartCoroutine(bestTactic.Execute(period));

            }
        }

    }




}


