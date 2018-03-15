using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class Defence : MonoBehaviour
    {
        public List<Armor> armor;
        public float EvasiveNess = 1;

        public event Action<float> GetDamaged;

        public bool CanIDodge(float speed, float Accuracy)
        {
            float val = UnityEngine.Random.Range(0, speed + Accuracy + EvasiveNess);
            return val < EvasiveNess;
        }

        public void GetHit(float dmg)
        {
            GetDamaged(dmg / armor.Sum((x) => x.Rating));
        }
    }
    public enum ArmorType
    {
        Helmet,Chest,Pants,Wrists
    }
}


