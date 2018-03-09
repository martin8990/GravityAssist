using System;
using System.Collections;

using UnityEngine;
namespace Infrastructure
{
    public abstract class Weapon : MonoBehaviour
    {
        public float AttackDamage;
        public float AttackTime;
        

        public event Action<float, GameObject> DoDamage;
        
        public abstract void DoAnim();
        public IEnumerator StartAttack(GameObject target,float SkillDmg)
        {
            DoAnim();
            yield return new WaitForSeconds(AttackTime);
            DoDamage(SkillDmg * AttackDamage, target);
        }
               
        
        
    }


}


