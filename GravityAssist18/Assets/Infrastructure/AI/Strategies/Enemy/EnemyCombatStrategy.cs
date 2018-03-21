using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System.Linq;
namespace Infrastructure
{
    [RequireComponent(typeof(DebugWeapon))]
    [RequireComponent(typeof(AttackTactic))]
    public class EnemyCombatStrategy : Strategy
    {
        AttackTactic attackTactic;
        DebugWeapon debugWeapon;
        public int AttackRange;
        private void Awake()
        {
            attackTactic = GetComponent<AttackTactic>();
            debugWeapon = GetComponent<DebugWeapon>();
            Func<List<Health>> GetSight = () => AIManager.friendlies.Map((x) => x.combatStrategy.health);
            Func<List<Health>> GetRange = () => AIManager.friendlies
            .Where((x) => Vector3.Distance(x.transform.position, transform.position) < AttackRange).ToList()
            .Map((x) => x.combatStrategy.health);
            attackTactic.init(GetSight, GetRange,debugWeapon.StartAttack);
            tactics.Add(attackTactic);
        }

        public override float GetStrategyUtility()
        {
           return 1;
        }
    }


}


