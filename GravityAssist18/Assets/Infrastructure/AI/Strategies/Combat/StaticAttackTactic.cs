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

    public class StaticAttackTactic : Tactic
    {
        Func<List<Health>> GetEnemiesInAttackRange;
        Action<Health> SetAttackTarget;


        public void init(
            Func<List<Health>> getEnemiesInAttackRange,
            Action<Health> setAttackTarget)
        {

            GetEnemiesInAttackRange = getEnemiesInAttackRange;
            SetAttackTarget = setAttackTarget;


        }

        public override float CalculateUtility()
        {
            var enemiesInAttackRange = GetEnemiesInAttackRange();
            for (int i = 0; i < enemiesInAttackRange.Count; i++)
            {
                if (enemiesInAttackRange[i] != null)
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
         

                var target = EnemiesInRange.Min((x) => Math.Abs((Vector3.Angle( transform.rotation.eulerAngles,x.transform.position - transform.position))));
                SetAttackTarget(target);      
            }
            yield return null;
        }



    }
}


