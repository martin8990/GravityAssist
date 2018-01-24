using System;
using System.Collections.Generic;

using UnityEngine;

namespace Infrastructure
{

    public class AIManager : MonoBehaviour
    {

        public List<AIUnit> AIUnits = new List<AIUnit>();
        public float updateTime = 1f;
        int i = 0;

        private void Start()
        {
            StartCoroutine(TriggerAI());
        }
        public System.Collections.IEnumerator TriggerAI()
        {

            yield return new WaitForSeconds(updateTime / AIUnits.Count);
            if (i <= AIUnits.Count - 1)
            {
                
            }
            else
            {
                i = 0;
            }
            AIUnits[i].Trigger(updateTime);
            i++;
            StartCoroutine(TriggerAI());
        }
        

    }
}


