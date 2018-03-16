using System.Collections;
using Utility;
using UnityEngine;
using UnityEngine.AI;
namespace Infrastructure
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class SimpleAttack : Tactic
    {
        public int dmg;
        NavMeshAgent navMeshAgent;
        public float attackRange;
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
            var players = PlayerManager.players;
            if (players.Count > 0)
            {
                var closestPlayer = players.Min((x) => transform.position.SquareDist2(x.transform.position));
                var closestDist = Vector3.Distance(closestPlayer.transform.position,transform.position);
                if (closestDist < attackRange)
                {
                    closestPlayer.Hit(dmg);
                    navMeshAgent.SetDestination(transform.position);

                }
                else
                {
                    navMeshAgent.SetDestination(closestPlayer.transform.position);
                }

            }            
                yield return null;
            
        }
    }


}


