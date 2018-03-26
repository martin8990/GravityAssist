using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using UnityEngine.AI;
using System.Collections;
namespace Infrastructure
{
    //public interface IAttackable
    //{
    //    void OnTakeDamage(int Damage);
    //    Transform transform { get;}     
    //}

    public class AttackTactic : Tactic
    {
        Func<List<Health>> GetEnemiesInSight;
        Func<List<Health>> GetEnemiesInAttackRange;
        Func<Vector3, IEnumerator> AttackTarget;
        public int Damage = 10;
        
        NavMeshAgent agent;

        public void init(Func<List<Health>> getEnemiesInSight,
            Func<List<Health>> getEnemiesInAttackRange,
            Func<Vector3, IEnumerator> attackTarget)
        {
            GetEnemiesInSight = getEnemiesInSight;
            GetEnemiesInAttackRange = getEnemiesInAttackRange;
            AttackTarget = attackTarget;

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

            var EnemiesInRange = GetEnemiesInAttackRange();

            if (EnemiesInRange.Count > 0)
            {
                agent.SetDestination(transform.position);

                var target = EnemiesInRange.Min((x) => Math.Abs((Vector3.Angle(x.transform.position, transform.position))));
                yield return StartCoroutine(AttackTarget(target.transform.position));
                if (GetEnemiesInAttackRange().Contains(target))
                {

                    target.TakeDamage(Damage, (x) => { });
                }
            }
            else
            {
                var EnemiesInSight = GetEnemiesInSight();
                if (EnemiesInSight.Count > 0)
                {
                    var closest = EnemiesInSight.Min((x) => transform.position.SquareDist2(x.transform.position));
                    agent.SetDestination(closest.transform.position);
                }
            }

            yield return null;
        }



    }
}


