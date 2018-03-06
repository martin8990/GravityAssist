using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Infrastructure
{

    public class AIUnit : MonoBehaviour
    {

        Material mat;

        public NavMeshAgent navMeshAgent;
        public TransportModule transportModule;
        public BuildModule constructionModule;
        public CFloat DestinationReachedMargin;

      //  public TaskBoard taskBoard;

        public List<Stockpile> stockPiles;
        Job prevJob;
        [HideInInspector]
        public Vector3 workSpace = Vector3.zero;

        public SkinnedMeshRenderer mr;

        private void Start()
        {
            mat = mr.material;
        }

        public void Trigger(int period)
        {
            if (prevJob != null)
            {
                prevJob.nUnitsAssigned--;
            }
            if (workSpace != Vector3.zero)
            {
              //  buildMap.FreeWorkspace(workSpace);
            }
            float bestUtil = 0;
            //Job bestJob = null;

            //foreach (var job in taskBoard.jobs)
            //{
            //    var util = job.CalculateUtility(this);


            //    if (util > bestUtil)
            //    {
            //        bestUtil = util;
            //        bestJob = job;

            //    }
            //}
            //mat.color = bestJob.DebugColor;
            //bestJob.Execute(this, period);
            //bestJob.nUnitsAssigned++;
            //prevJob = bestJob;



        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(workSpace, Vector3.one);
        }
    }


}


