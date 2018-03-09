using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Infrastructure
{

    public class AIUnit : MonoBehaviour
    {
        public CFloat DestinationReachedMargin;

        public List<Tactic> tactics;
        public List<Stockpile> stockPiles;

        Tactic prevTactic;

        public void Trigger(int period)
        {
            float bestUtil = 0;

            Tactic bestTactic = null;
            foreach (var tactic in tactics)
            {
                var util = tactic.CalculateUtility(this);
                if (util > bestUtil)
                {
                    bestUtil = util;
                    bestTactic = tactic;
                }
            }
            bestTactic.Execute(this, period);
            prevTactic = bestTactic;
        }        
    }


}


