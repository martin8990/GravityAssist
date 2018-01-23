using System;
using System.Collections.Generic;

using UnityEngine;

namespace Infrastructure
{
    public class AIManager : MonoBehaviour
    {

        public List<AIModule> AIunits = new List<AIModule>();
        public List<AIModule> HighSpeedAIunits = new List<AIModule>();

        public float updateTime = 1f;

        public float updateTimeHighSpeed = 0.1f;
        int i = 0;

        private void Start()
        {
            StartCoroutine(TriggerAI());
        }
        public System.Collections.IEnumerator TriggerAI()
        {
            if (i <= AIunits.Count - 1)
            {
                AIunits[i].Trigger(updateTime);
            }
            else
            {
                i = 0;
            }
            yield return new WaitForSeconds(updateTime/AIunits.Count);
        }
        public System.Collections.IEnumerator TriggerHighSpeedAI()
        {
            if (i <= HighSpeedAIunits.Count - 1)
            {
                HighSpeedAIunits[i].Trigger(updateTime);
            }
            else
            {
                i = 0;
            }
            yield return new WaitForSeconds(updateTime / HighSpeedAIunits.Count);
        }

    }


}


