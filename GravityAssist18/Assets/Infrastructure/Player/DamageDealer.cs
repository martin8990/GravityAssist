using System;
using UnityEngine;

namespace Infrastructure
{
    public class DamageDealer : MonoBehaviour
    {
        public event Action<int> ReceiveScore;
        public int Damage;
        private void Awake()
        {
            ReceiveScore += (x) => { };
        }
        public void DealDamage(Health target)
        {
            target.TakeDamage(Damage, ReceiveScore);

        }
    }




}


