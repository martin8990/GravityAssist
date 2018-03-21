using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System.Linq;
namespace Infrastructure
{
    [RequireComponent(typeof(NexusTactic))]
    [RequireComponent(typeof(Health))]
    public class EnemyCombatStrategy : Strategy
    {
        Health health;
        AIUnit aIUnit;
        NexusTactic nexusTactic;
        private void Awake()
        {
            health = GetComponent<Health>();
            health.OnDeath += () => OnDeath();            
            aIUnit = GetComponent<AIUnit>();
            nexusTactic = GetComponent<NexusTactic>();
            nexusTactic.Init(OnDeath);
            tactics.Add(nexusTactic);
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


