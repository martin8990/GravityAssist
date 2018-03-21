using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using Utility;
using System;

namespace Infrastructure
{

    [RequireComponent(typeof(NavMeshAgent))]
    public class NexusTactic : Tactic
    {
        NavMeshAgent navMeshAgent;
        public CFloat destReachedMargin;
        public int dmg;
        public event Action OnDeath;

        public void Init(Action todoOnDeath)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            OnDeath += todoOnDeath;
        }
        public override float CalculateUtility()
        {
            return 1;
        }

        public override IEnumerator Execute(int Period)
        {
            var dest = transform.position;
            if (Nexus.nexus != null)
            {
                dest = Nexus.nexus.transform.position;
            }
            if (transform.position.SquareDist2(dest) > destReachedMargin)
            {
                navMeshAgent.SetDestination(dest);
            }
            else
            {
                Nexus.nexus.Hit(dmg);
                OnDeath();
            }
            yield return null;

        }
    }
}


