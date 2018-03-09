using System;
using UnityEngine;
namespace Infrastructure
{
    public class Defence : MonoBehaviour
    {
        public float ArmorRating = 1;
        public float EvasiveNess = 1;

        public event Action<float> GetDamaged;

        public bool IsHit(float HitChance)
        {
            float hit = UnityEngine.Random.Range(0f, HitChance + EvasiveNess);
            if (hit < HitChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetHit(float dmg)
        {
            GetDamaged(dmg / ArmorRating);
        }
    }
}


