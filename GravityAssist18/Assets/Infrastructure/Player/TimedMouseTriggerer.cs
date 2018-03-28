using System;
using UnityEngine;
namespace Infrastructure
{
    public class TimedMouseTriggerer : MonoBehaviour
    {
        public float interval = 0.1f;
        float t;
        public event Action OnTrigger;

        private void Update()
        {
            t += Time.deltaTime;
            if (Input.GetMouseButton(0) && t > interval)
            {
                t = 0;
                OnTrigger();
            }
        }
    }






}


