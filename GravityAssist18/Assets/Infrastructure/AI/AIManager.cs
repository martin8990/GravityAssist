using System;
using System.Collections.Generic;

using UnityEngine;

namespace Infrastructure
{
    public class AIManager : MonoBehaviour
    {

        public List<AIModule> AIUnits = new List<AIModule>();
        public List<AIModule> HighSpeedAIUnits = new List<AIModule>();

        public float updateTime = 1f;

        public float updateTimeHighSpeed = 0.1f;
        int i = 0;

        private void Start()
        {
            StartCoroutine(TriggerAI());
        }
        public System.Collections.IEnumerator TriggerAI()
        {
            if (i <= AIUnits.Count - 1)
            {
                
            }
            else
            {
                i = 0;
            }
            AIUnits[i].Trigger(updateTime);
            yield return new WaitForSeconds(updateTime/AIUnits.Count);
            i++;
            StartCoroutine(TriggerAI());
        }
        public System.Collections.IEnumerator TriggerHighSpeedAI()
        {
            if (i <= HighSpeedAIUnits.Count - 1)
            {
                HighSpeedAIUnits[i].Trigger(updateTime);
            }
            else
            {
                i = 0;
            }
            yield return new WaitForSeconds(updateTime / HighSpeedAIUnits.Count);
        }

    }


}


