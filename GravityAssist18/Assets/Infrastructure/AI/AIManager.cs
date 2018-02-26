//using System;
//using System.Collections.Generic;

//using UnityEngine;
//namespace Infrastructure
//{

//    public class AIManager : MonoBehaviour
//    {

//        public List<AIUnit> AIUnits = new List<AIUnit>();
//        public int Period = 1000;//ms
//        int i = 0;

//        private void Start()
//        {
//            StartCoroutine(TriggerAI());
//        }
//        public System.Collections.IEnumerator TriggerAI()
//        {
//            if (AIUnits.Count > 0)
//            {
//                yield return new WaitForSeconds(Period / AIUnits.Count / 1000f);
//                if (i <= AIUnits.Count - 1)
//                {

//                }
//                else
//                {
//                    i = 0;
//                }
//                AIUnits[i].Trigger(Period);
//                i++;
//                StartCoroutine(TriggerAI());
//            }
//            else
//            {
//                yield return null;
//                StartCoroutine(TriggerAI());

//            }
//        }
        

//    }
//}


