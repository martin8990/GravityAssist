using UnityEngine;
using Utility;

namespace Infrastructure
{


    [RequireComponent(typeof(TurretWeapon))]
    [RequireComponent(typeof(StaticAttackTactic))]
    public class TurretCombatStrategy : Strategy
    {

        TurretWeapon turretWeapon;
        StaticAttackTactic attackTactic;
        
        Triggerer inRange;
        FriendlyAIUnit aiUnit;
        public float attackRange = 20;
        public CIntArr enemyMasks;

        public override float GetStrategyUtility()
        {
            if (inRange.TriggeredObjects.Count > 0)
            {

                return 0.9f;
            }
            else
            {
                return 0;
            }
        }

        private void Awake()
        { 
            inRange = Triggerer.AddSphereTrigger(transform, "attackRange", attackRange, enemyMasks,gameObject.layer);
 
            turretWeapon = GetComponent<TurretWeapon>();
            attackTactic = GetComponent<StaticAttackTactic>();
            attackTactic.init(inRange.GetComponentsInTrigger<Health>,(x) => turretWeapon.target = x);

            tactics.Add(attackTactic);
        }
    }


}


