using UnityEngine;
using Utility;

namespace Infrastructure
{
    
    [RequireComponent(typeof(AttackTactic))]
    public class FriendlyCombatStrategy : Strategy
    {
        [HideInInspector]
        public Health health;

        AttackTactic attackTactic;
        Triggerer sight;
        Triggerer inRange;
        FriendlyAIUnit aiUnit;
        public float sightRange = 20;
        public float attackRange = 20;
        public CIntArr enemyMasks;

        public override float GetStrategyUtility()
        {
            if (sight.TriggeredObjects.Count > 0)
            {
                Debug.Log("EnemyInSight");
                return 0.9f;
            }
            else
            {
                return 0;
            }
        }

        private void Awake()
        { 
            sight = Triggerer.AddSphereTrigger(transform, "sight", sightRange, enemyMasks);
            inRange = Triggerer.AddSphereTrigger(transform, "attackRange", attackRange, enemyMasks);
            aiUnit = GetComponent<FriendlyAIUnit>();
            
            attackTactic = GetComponent<AttackTactic>();
            attackTactic.init(sight.GetComponentsInTrigger<Health>,inRange.GetComponentsInTrigger<Health>);

            tactics.Add(attackTactic);

            health = GetComponent<Health>();
            health.OnDeath += () => AIManager.friendlies.Remove(aiUnit);
            health.OnDeath += () => AIManager.AIUnits.Remove(aiUnit);
            health.OnDeath += () => Destroy(gameObject);
        }

        


    }

}


