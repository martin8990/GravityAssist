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

        public Action<Color> SetColor;
        public Action<Vector3> SetDestination;
        //public Func<List<GameObject>> GetCloseRange;
        //public Func<List<GameObject>> GetMediumRange;

        public void Trigger(int period)
        {
            if (prevTactic != null)
            {
                prevTactic.nUnitsAssigned--;
            }
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


