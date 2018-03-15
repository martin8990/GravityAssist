using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using Utility;
namespace Infrastructure
{

    [RequireComponent(typeof(NavMeshAgent))]    
    public class NexusTactic : Tactic
    {
        NavMeshAgent navMeshAgent;
        public CFloat destReachedMargin;
        public Nexus nexus;
        public int dmg;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public override float CalculateUtility()
        {
            return 0.5f;
        }

        public override IEnumerator Execute(int Period)
        {
            var dest = nexus.transform.position;
            if (transform.position.SquareDist2(dest) > destReachedMargin)
            {
                navMeshAgent.SetDestination(dest);
            }
            else
            {
                nexus.Hit(dmg);
                Destroy(gameObject);
            }
            yield return null;

        }
    }
}


