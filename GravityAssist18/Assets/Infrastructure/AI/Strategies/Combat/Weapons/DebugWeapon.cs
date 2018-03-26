using System.Collections;

using UnityEngine;
namespace Infrastructure
{
    public class DebugWeapon : Weapon
    {
        public Animator anim;
        public float Range;
        public float attackTime;
        public string attackStateName;
        bool attacking;
        Vector3 target;
        public void Update()
        {
            if (attacking)
            {
                transform.LookAt(target);
            }
        }

        public override IEnumerator StartAttack(Vector3 _target)
        {
            target = _target;
            attacking = true;
            anim.Play(attackStateName);
            yield return new WaitForSeconds(attackTime);
            attacking = false;
        }
    }


}


