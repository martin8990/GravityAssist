using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Utility;
namespace Infrastructure
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveOrder : Order
    {
        
        public Vector3 destination;
        float margin = 1;
        NavMeshAgent navMeshAgent;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        

        public override void Execute(int Period)
        {
            if (transform.position.SquareDist2(destination) < margin)
            {
                navMeshAgent.SetDestination(transform.position);
                OnComplete();
            }
            else
            {
                navMeshAgent.SetDestination(destination);
            }
        }
    }

}


