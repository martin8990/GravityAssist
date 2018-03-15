using System.Collections;

using UnityEngine;
using UnityEngine.AI;

namespace Infrastructure
{

    public class DebugTactic : Tactic
    {
        NavMeshAgent agent;
        public Transform target;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        public override float CalculateUtility()
        {
            return 1;
        }

        public override IEnumerator Execute(int Period)
        {
            agent.SetDestination(target.position);
            yield return null;
        }
    }




}


