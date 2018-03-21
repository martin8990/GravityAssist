using System;
using System.Collections;

using UnityEngine;
namespace Infrastructure
{


    public abstract class Weapon : MonoBehaviour
    {

        public abstract IEnumerator StartAttack(Vector3 target);              
        
        
    }

    public class Unarmed : Weapon
    {
        public override IEnumerator StartAttack(Vector3 target)
        {
            throw new NotImplementedException();
        }
    }


}


