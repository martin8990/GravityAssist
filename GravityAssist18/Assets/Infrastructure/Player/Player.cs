using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{

    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(MiningModule))]
    public class Player : MonoBehaviour
    {
        [HideInInspector]
        public MiningModule miningModule;
        public float ActionPoints = 100;
        public List<Func<float>> playerActions = new List<Func<float>>();
        [HideInInspector]
        public Health health;
        public List<Tool> tools = new List<Tool>();
        int toolIndex = 0;


        private void Awake()
        {
            health = GetComponent<Health>();
            health.OnDeath+=() => Debug.Log("player down");
            miningModule = GetComponent<MiningModule>();
           
            if (!MainPlayerUI.players.Contains(this))
            {
                MainPlayerUI.players.Add(this);
            }

        }
        public void Update()
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                tools[toolIndex].gameObject.SetActive(false);                    
                toolIndex++;
                if (toolIndex > tools.Count-1)
                {
                    toolIndex = 0;
                }
                tools[toolIndex].gameObject.SetActive(true);
            }
        }



    }
    public class PlayerAction
    {
        public Action Paction;
        public Func<float> getCost;
    }
}





