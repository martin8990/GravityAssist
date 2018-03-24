using System.Collections;

using UnityEngine;
namespace Infrastructure
{
    public class DebugWeapon : Weapon
    {
        public float Range;
        
        public override IEnumerator StartAttack(Vector3 target)
        {
            transform.LookAt(target);
            yield return null;
            
        }
    }


}


