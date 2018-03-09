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
        public Action<float, float, float> OnHit;

        public override float CalculateUtility(AIUnit aiUnit)
        {
            if (GetAttackRating()+GetArmorRating() > 0)
            {
                if (GetEnemiesInMeleeRange().Count > 0)
                {
                    return GetAttackRating() + GetArmorRating();
                }
                else if(GetEnemiesInSight().Count > 0)
                {
                    return GetAttackRating() + GetArmorRating() / 2f;
                }
            }
            
            return 0;
            
        }

        public override IEnumerator Execute(AIUnit aiUnit, int Period)
        {
            var EnemiesInRange = GetEnemiesInMeleeRange();
            if (EnemiesInRange.Count > 0)
            {
                agent.SetDestination(transform.position);
                var target = EnemiesInRange[0];
                OnHit = target.GetComponent<Defence>().GetHit;
                StartCoroutine( OnAttack(target));
            }
            else
            {
                var EnemiesInSight = GetEnemiesInSight();
                var closest = EnemiesInSight.Min((x) => transform.position.SquareDist2(x.transform.position));
                agent.SetDestination(closest.transform.position);
            }
            yield return null;
            
        }
    }
}


