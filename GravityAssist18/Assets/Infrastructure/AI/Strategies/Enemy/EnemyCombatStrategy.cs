using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System.Linq;
namespace Infrastructure
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(AttackTactic))]
    [RequireComponent(typeof(DebugWeapon))]
    public class EnemyCombatStrategy : Strategy
    {
        Health health;
        AIUnit aIUnit;
        AttackTactic playerAttack;
        DebugWeapon debugWeapon;
        private void Awake()
        {
            health = GetComponent<Health>();
            health.OnDeath += () => OnDeath();            
            aIUnit = GetComponent<AIUnit>();
            debugWeapon = GetComponent<DebugWeapon>();
            playerAttack = GetComponent<AttackTactic>();
            Func<List<Health>> inRange = (() => MainPlayerUI.players.Map((x) => x.health).Where((x) => Vector3.Distance(x.transform.position, transform.position) < debugWeapon.Range).ToList());
            Func<List<Health>> inSight = (() => MainPlayerUI.players.Map((x) => x.health));


            playerAttack.init(inSight,inRange,debugWeapon.StartAttack);
            tactics.Add(playerAttack);
        }
        public override float GetStrategyUtility()
        {
            return 1;
        }
        void OnDeath()
        {
            Debug.Log("death");
            AIManager.AIUnits.Remove(aIUnit);
            Destroy(gameObject);
        }

    }


}


