//using System.Collections.Generic;

//using UnityEngine;
//using Utility;
//namespace Infrastructure
//{


//    [RequireComponent(typeof(AIUnit))]
//    [RequireComponent(typeof(AttackTactic))]
//    public class CombatModule : MonoBehaviour
//    {
//        AIUnit aiUnit;
//        AttackTactic attackTactic;
//        Triggerer sight;
//        Triggerer nearby;
//        public Weapon weapon;

//        public float sightRange = 20;
//        public float attackRange = 2;
//        public CIntArr enemyMasks;

//        private void Awake()
//        {
//            aiUnit = GetComponent<AIUnit>();
//            attackTactic = GetComponent<AttackTactic>();
//            sight = Triggerer.AddSphereTrigger(transform, "sight", sightRange, enemyMasks);
//            sight = Triggerer.AddSphereTrigger(transform, "attackRange", attackRange, enemyMasks);
//            attackTactic.OnAttack += weapon.StartAttack;
//            weapon.DoDamage += (x,y) => y.GetComponent<>

//        }
//    }


//}


