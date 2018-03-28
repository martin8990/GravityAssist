using System;
using System.Collections.Generic;
using UnityEngine;
namespace Infrastructure
{



    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(TimedTriggerer))]
    public class Player : MonoBehaviour
    {
         [HideInInspector]
        public Health health;
        public List<GameObject> tools = new List<GameObject>();
        TimedTriggerer healthRegenTriggerer;
        int toolIndex = 0;

        private void Awake()
        {
            healthRegenTriggerer = GetComponent<TimedTriggerer>();
            health = GetComponent<Health>();

            healthRegenTriggerer.OnTrigger+=() => health.Heal(1f);
            health.OnDeath+=() => Debug.Log("player down");
  
            
           
            if (!MainPlayerUI.players.Contains(this))
            {
                MainPlayerUI.players.Add(this);
            }

        }
        public void Update()
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                tools[toolIndex].SetActive(false);                    
                toolIndex++;
                if (toolIndex > tools.Count-1)
                {
                    toolIndex = 0;
                }
                tools[toolIndex].SetActive(true);
            }
        }

       


    }
}






