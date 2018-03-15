﻿
using UnityEngine;
using Utility;
namespace Infrastructure
{

    [RequireComponent(typeof(AIUnit))]
    [RequireComponent(typeof(AttackTactic))]
    [RequireComponent(typeof(PhysicalSkills))]
    [RequireComponent(typeof(Defence))]
    [RequireComponent(typeof(Health))]
    public class CombatStrategy : Strategy
    {
        

        AIUnit aiUnit;
        AttackTactic attackTactic;
        PhysicalSkills physicalSkills;
        Triggerer sight;
        Triggerer nearby;
        Defence defence;
        Health health;

        public float sightRange = 20;
        public float attackRange = 2;
        public CIntArr enemyMasks;
        public Weapon weapon;
        
        private void Awake()
        {
            aiUnit = GetComponent<AIUnit>();
            attackTactic = GetComponent<AttackTactic>();
            physicalSkills = GetComponent<PhysicalSkills>();
            health = GetComponent<Health>();
            defence = GetComponent<Defence>();

            sight = Triggerer.AddSphereTrigger(transform, "sight", sightRange, enemyMasks);
            nearby = Triggerer.AddSphereTrigger(transform, "attackRange", attackRange, enemyMasks);

            weapon.init(() => physicalSkills.Strength, () => physicalSkills.Agility);
     
            attackTactic.OnAttack += weapon.StartAttack;
            attackTactic.GetEnemiesInSight = (() => sight.TriggeredObjects);
            attackTactic.GetEnemiesInMeleeRange = (() => nearby.TriggeredObjects);
            defence.GetDamaged += health.TakeDamage;
            health.OnDeath += () => Destroy(gameObject);
        }

        public override float GetStrategyUtility()
        {
            return 1;
        }
    }


}


