using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
namespace Infrastructure
{

    public class AIManager : MonoBehaviour
    {
        public List<AIUnit> ToAdd = new List<AIUnit>();

        public static List<AIUnit> AIUnits = new List<AIUnit>();
 //       public static List<FriendlyAIUnit> friendlies = new List<FriendlyAIUnit>();
        public int Period = 1000;//ms
        int i = 0;
        public static void OnGameOver()
        {
            AIUnits = new List<AIUnit>();
        }
        private void Start()
        {
            ToAdd.Iter((x) => AIUnits.Add(x));
            StartCoroutine(TriggerAI());
        }
        public static void AddAI(AIUnit aIUnit)
        {

            AIUnits.Add(aIUnit);
        }
        public IEnumerator TriggerAI()
        {

            if (AIUnits.Count > 0)
            {
                if (i <= AIUnits.Count - 1)
                {

                }
                else
                {
                    i = 0;
                }
                StartCoroutine(AIUnits[i].Trigger(Period));
                i++;
                yield return new WaitForSeconds(Period / AIUnits.Count / 1000f);

                StartCoroutine(TriggerAI());
            }
            else
            {
                yield return null;
                StartCoroutine(TriggerAI());

            }


        }


    }
}


