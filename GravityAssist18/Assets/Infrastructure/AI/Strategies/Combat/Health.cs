using System;
using UnityEngine;
namespace Infrastructure
{
    public class Health : MonoBehaviour
    {
        public float MaxHP = 100;
        public float CurrentHP = 100;

        public event Action OnDeath;
        public event Action<float> OnHealthChange = delegate { };
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
            OnHealthChange(CurrentHP);
        }
        public void Heal(float healing)
        {
            var prevHP = CurrentHP;
            CurrentHP = Mathf.Min(MaxHP,CurrentHP+ healing);
            if (CurrentHP>prevHP)
            {
                OnHealthChange(CurrentHP);
            }
        }


    }

    
}


