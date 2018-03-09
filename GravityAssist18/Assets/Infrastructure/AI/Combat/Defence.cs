using System;
using System.Collections.Generic;
using UnityEngine;
namespace Infrastructure
{
    public class Defence : MonoBehaviour
    {
        public List<Armor> armor;
        public float ArmorRating = 1;
        public float EvasiveNess = 1;

        public event Action<float> GetDamaged;

        public void GetHit(float dmg,float speed,float Accuracy)
        {
            GetDamaged(dmg / ArmorRating);
        }
    }
    public enum ArmorType
    {
        Helmet,Chest,Pants,Wrists
    }
    public static class CombatCalculations
    {
        public static float DefenceRating()
        {

        }
    }
}


