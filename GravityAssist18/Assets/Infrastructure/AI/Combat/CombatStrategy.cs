using System.Collections.Generic;

using UnityEngine;
using Utility;
namespace Infrastructure
{

    [RequireComponent(typeof(AIUnit))]
    [RequireComponent(typeof(AttackTactic))]
    [RequireComponent(typeof(PhysicalSkills))]
    public class CombatStrategy : MonoBehaviour
    {
        AIUnit aiUnit;
        AttackTactic attackTactic;
        PhysicalSkills physicalSkills;
        Triggerer sight;
        Triggerer nearby;

        public float sightRange = 20;
        public float attackRange = 2;
        public CIntArr enemyMasks;
        public Weapon weapon;
        
        
        private void Awake()
        {
            aiUnit = GetComponent<AIUnit>();
            attackTactic = GetComponent<AttackTactic>();
            physicalSkills = GetComponent<PhysicalSkills>();
            sight = Triggerer.AddSphereTrigger(transform, "sight", sightRange, enemyMasks);
            sight = Triggerer.AddSphereTrigger(transform, "attackRange", attackRange, enemyMasks);
            weapon.init(() => physicalSkills.Strenght, () => physicalSkills.Agility);
            weapon.OnHit += attackTactic.OnHit; // Does this work?
            attackTactic.OnAttack += weapon.StartAttack;
        }

    }


}


