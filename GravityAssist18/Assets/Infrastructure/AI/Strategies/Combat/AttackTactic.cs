using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using UnityEngine.AI;
using System.Collections;

namespace Infrastructure
{


    public class AttackTactic : Tactic
    {
        
        public Func<float> GetArmorRating;
        public Func<float> GetAttackRating;

        public Func<List<GameObject>> GetEnemiesInSight;
        public Func<List<GameObject>> GetEnemiesInMeleeRange;
        
        public event Func<GameObject, IEnumerator> OnAttack;
        
        NavMeshAgent agent;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public override float CalculateUtility()
        {
            var enemiesInSight = GetEnemiesInSight();
            for (int i = 0; i < enemiesInSight.Count; i++)
            {
                if (enemiesInSight[i] != null)
                {
                    return 1;
                }                
           }
            return 0;

            
        }

        public override IEnumerator Execute(int Period)
        {
            var EnemiesInRange = GetEnemiesInMeleeRange();
            if (EnemiesInRange.Count > 0)
            {
                agent.SetDestination(transform.position);
                var target = EnemiesInRange[0];
          
                StartCoroutine( OnAttack(target));
            }
            else
            {
                var EnemiesInSight = GetEnemiesInSight();
                if (EnemiesInSight.Count>0)
                {
                    Debug.Log("Enemies " + EnemiesInSight.Count);
                    var closest = EnemiesInSight.Min((x) => transform.position.SquareDist2(x.transform.position));
                    agent.SetDestination(closest.transform.position);
                }          
            }
            yield return null;            
        }



    }
}


