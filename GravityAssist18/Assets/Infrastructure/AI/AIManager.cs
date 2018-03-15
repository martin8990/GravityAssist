using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
namespace Infrastructure
{

    public class AIManager : MonoBehaviour
    {
        public List<AIUnit> AIUnits = new List<AIUnit>();
        public int Period = 1000;//ms
        int i = 0;
        public bool GameOver;
        private void Start()
        {
            AIUnits.Iter((x) => x.OnRemove = (() => AIUnits.Remove(x)));
            StartCoroutine(TriggerAI());
        }
        public void AddAI(AIUnit aIUnit)
        {
            aIUnit.OnRemove = (() => AIUnits.Remove(aIUnit));
            AIUnits.Add(aIUnit);
        }
        public IEnumerator TriggerAI()
        {
            if (!GameOver)
            {
                if (AIUnits.Count > 0)
                {
                    yield return new WaitForSeconds(Period / AIUnits.Count / 1000f);
                    if (i <= AIUnits.Count - 1)
                    {

                    }
                    else
                    {
                        i = 0;
                    }
                    AIUnits[i].Trigger(Period);
                    i++;
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
}


