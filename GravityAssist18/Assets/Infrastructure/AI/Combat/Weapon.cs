using System;
using System.Collections;

using UnityEngine;
namespace Infrastructure
{
    public abstract class Weapon : MonoBehaviour
    {
        // AM = Agility modifier;
        // SM = Strength modifier;
        // B = Base
        public float Damage_B;

        public float Damage_AM;
        public float Damage_SM;

        public float Speed_B;

        public float Speed_AM;
        public float Speed_SM;

        public float Accuracy_B;

        public float Accuracy_AM;
        public float Accuracy_SM;

        public Func<float> GetStrength;
        public Func<float> GetAgility;

        public void init(Func<float> getStrength, Func<float> getAgility)
        {
            GetStrength = getStrength;
            GetAgility = getAgility;
        }

        public event Action<float, float, float> OnHit;
        
        public abstract void DoAnim();
        public IEnumerator StartAttack(GameObject target)
        {
            DoAnim();
            var A = GetAgility();
            var S = GetStrength();
            var damage = Damage_B + Damage_AM * A + Damage_SM * S;
            var accuracy = Accuracy_B + Accuracy_AM * A + Accuracy_SM * S;
            var speed = Speed_B + Speed_AM * A + Speed_SM * S;
            yield return new WaitForSeconds(1f/speed);
            OnHit(damage,speed,accuracy);
        }
               
        
        
    }


}


