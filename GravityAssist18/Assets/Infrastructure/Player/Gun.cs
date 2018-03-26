using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{

    public class Gun : Tool
    {
        public int DMG = 10;
        public event Action<int> RecieveScore;
        public Transform grip;
        public int RecoilFrames;
        public float recoilPerFrame;

        public override void OnHit(GameObject target)
        { 
            target.GetComponent<Health>().TakeDamage(DMG, RecieveScore);

        }

        public override void OnUse()
        {
            StartCoroutine(Recoil());
        }
        IEnumerator Recoil()
        {
            for (int i = 0; i < recoilPerFrame; i++)
            {
                var prevPos = grip.transform.localPosition;
                grip.transform.localPosition = new Vector3(prevPos.x, prevPos.y, prevPos.z - recoilPerFrame);
                yield return new WaitForSecondsRealtime(0.016f);
            }
            for (int i = 0; i < recoilPerFrame; i++)
            {
                var prevPos = grip.transform.localPosition;
                grip.transform.localPosition = new Vector3(prevPos.x, prevPos.y, prevPos.z + recoilPerFrame);
                yield return new WaitForSecondsRealtime(0.016f);
            }


        }
    }




}


