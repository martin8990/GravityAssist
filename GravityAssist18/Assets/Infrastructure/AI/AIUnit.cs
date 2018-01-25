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
        public CFloat DestinationReachedMargin;
        public TaskBoard taskBoard;
        public List<Stockpile> stockPiles;


        private void Start()
        {
            mat = GetComponent<MeshRenderer>().material;
            navMeshAgent = this.GetComponent<NavMeshAgent>();
        }

        public void Trigger(float period)
        {
            float bestUtil = 0;
            Job bestTasks = null;
            Debug.Log(taskBoard.tasks.Count);
            foreach (var task in taskBoard.tasks)
            {
                var util = task.CalculateUtility(this);

                Debug.Log(task.GetType().Name + " : " + util);
                if (util > bestUtil)
                {
                    bestUtil = util;
                    bestTasks = task;

                }
            }
            mat.color = bestTasks.DebugColor;
            bestTasks.Execute(this, period);
            
                

        }
    }


}


