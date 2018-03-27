using System;
using UnityEngine;
namespace Infrastructure
{
    public class TimedTriggerer : MonoBehaviour
    {

        public float interval = 0.1f;
        float t;
        bool hashit = false;
        public event Action OnTrigger;

        private void Update()
        {
            hashit = false;
            t += Time.deltaTime;
            if (Input.GetMouseButton(0) && t > interval)
            {
                t = 0;
                OnTrigger();
            }
        }

    }    




}


