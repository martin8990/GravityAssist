//using System.Collections;
//using UnityEngine.AI;
//using UnityEngine;
//using Utility;
//using System;

//namespace Infrastructure
//{

//    [RequireComponent(typeof(NavMeshAgent))]    
//    public class NexusTactic : Tactic
//    {
//        NavMeshAgent navMeshAgent;
//        public CFloat destReachedMargin;
//        public int dmg;

//        private void Awake()
//        {
//            navMeshAgent = GetComponent<NavMeshAgent>();
//        }
//        public override float CalculateUtility()
//        {
//            return 0.5f;
//        }

//        public override IEnumerator Execute(int Period)
//        {
//            var dest = transform.position;
//            if (Nexus.nexus!=null)
//            {
//                dest = Nexus.nexus.transform.position;
//            }

            
//            if (transform.position.SquareDist2(dest) > destReachedMargin)
//            {
//                navMeshAgent.SetDestination(dest);
//            }
//            else
//            {
//                Nexus.nexus.Hit(dmg);
//                GetComponent<AIUnit>().OnRemove();
//                Destroy(gameObject);
//            }
//            yield return null;

//        }
//    }
//}


