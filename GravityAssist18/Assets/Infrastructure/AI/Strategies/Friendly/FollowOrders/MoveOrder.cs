using System.Collections;
using UnityEngine;
using UnityEngine.AI;
namespace Infrastructure
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveOrder : Tactic
    {
        
        public Vector3 destination;
        NavMeshAgent navMeshAgent;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public override float CalculateUtility()
        {
            return 1;
        }

        public override IEnumerator Execute(int Period)
        {
            navMeshAgent.SetDestination(destination);
            yield return null;
        }
    }

}


