//using System;
//using System.Collections.Generic;
//using UnityEngine;
//namespace Infrastructure
//{
//    [RequireComponent(typeof(Health))]
//    [RequireComponent(typeof(MiningModule))]
//    public class Player : MonoBehaviour
//    {
//        [HideInInspector]
//        public MiningModule miningModule;
//        public float ActionPoints = 100;
//        public List<Func<float>> playerActions = new List<Func<float>>();
//        [HideInInspector]
//        public Health health;

//        private void Awake()
//        {
//            health = GetComponent<Health>();
//            miningModule = GetComponent<MiningModule>();
//            if (!MainPlayerUI.players.Contains(this))
//            {
//                MainPlayerUI.players.Add(this);
//            }
 
//        }
//        public void EndTurn()
//        {
//            Debug.Log(playerActions.Count);
//            while (playerActions.Count > 0 && ActionPoints > 0)
//            {
//                ActionPoints -= playerActions[0]();
//                playerActions.RemoveAt(0);
                
//            }
//            ActionPoints = 100;
//            Debug.Log("Done");

//        }

//    }
//    public class PlayerAction
//    {
//        public Action Paction;
//        public Func<float> getCost;
//    }
//}
    




