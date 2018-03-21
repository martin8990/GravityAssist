using System;
using UnityEngine;
namespace Infrastructure
{
    public class Nexus : MonoBehaviour
    {
        public static Nexus nexus;
        private void Awake()
        {
            nexus = this;           
        }

        public int HP = 100;
        public void Hit(int dmg)
        {
            HP -= dmg;
            if (HP==0)
            {
                AIManager.OnGameOver();
                Debug.Log("Game over");
             

            }
        }
    }



}


