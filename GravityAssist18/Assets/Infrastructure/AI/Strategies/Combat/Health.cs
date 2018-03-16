using System;
using UnityEngine;
namespace Infrastructure
{
    public class Health : MonoBehaviour
    {
        public float MaxHP = 100;
        public float CurrentHP = 100;

        public event Action OnDeath;

        public void TakeDamage(int dmg,Action<int> returnScore)
        {
            CurrentHP -= dmg;
            if (CurrentHP<=0)
            {
                OnDeath();
                CurrentHP = 0;
                returnScore(100 + dmg);
            }
            else
            {
                returnScore(dmg);
            }
        }
        public void Heal(float healing)
        {
            CurrentHP = Mathf.Min(MaxHP,CurrentHP+ healing);            
        }


    }
}


