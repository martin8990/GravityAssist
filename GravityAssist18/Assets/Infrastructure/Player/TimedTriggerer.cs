using System;
using UnityEngine;
namespace Infrastructure
{
    public class TimedTriggerer : MonoBehaviour
    {
        public float interval = 0.1f;
        float t;
        public event Action OnTrigger;

        private void Update()
        {
            t += Time.deltaTime;
            if (t > interval)
            {
                t = 0;
                OnTrigger();
            }
        }
    }






}


