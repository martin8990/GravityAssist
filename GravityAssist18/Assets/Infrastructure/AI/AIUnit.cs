using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Infrastructure
{
    public class AIUnit : MonoBehaviour
    {
       
        Material mat;
        [HideInInspector]
        public NavMeshAgent navMeshAgent;
        public TransportModule transportModule;
        public ConstructionModule constructionModule;
        public CFloat DestinationReachedMargin;
        public TaskBoard taskBoard;
        public List<Stockpile> stockPiles;
        Job prevJob;
        public Workspace workspace;

        private void Start()
        {
            mat = GetComponent<MeshRenderer>().material;
            navMeshAgent = this.GetComponent<NavMeshAgent>();
        }

        public void Trigger(int period)
        {
            if (prevJob!=null)
            {
                prevJob.nUnitsAssigned--;
            }
            if (workspace != null)
            {
                workspace.Reserved = false;
            }
            float bestUtil = 0;
            Job bestJob = null;

            foreach (var job in taskBoard.jobs)
            {
                var util = job.CalculateUtility(this);


                if (util > bestUtil)
                {
                    bestUtil = util;
                    bestJob = job;

                }
            }
            mat.color = bestJob.DebugColor;
            bestJob.Execute(this, period);
            bestJob.nUnitsAssigned++;
            prevJob = bestJob;
            
                

        }
    }


}


