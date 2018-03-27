using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    [RequireComponent(typeof(TimedTriggerer))]
    [RequireComponent(typeof(CameraRayCaster))]
    [RequireComponent(typeof(UseEffectPlayer))]
    [RequireComponent(typeof(HitMarker))]

    public class Gun : MonoBehaviour
    {
        public int DMG = 10;
        public HitEffect hitEffect;

        TimedTriggerer timedTrigger;
        CameraRecursiveRayCaster rayCaster;
        HitMarker hitMarker;
        UseEffectPlayer useEffect;
        DamageDealer damageDealer;
        ScoreKeeper scoreKeeper;
        private void Awake()
        {
            timedTrigger.OnTrigger += rayCaster.RaycastRecursively;
            timedTrigger.OnTrigger += useEffect.PlayUseEffect;
            rayCaster.OnHitGO += (x) => hitEffect.Hit(x.transform.position);
            rayCaster.OnHitGO += (x) => damageDealer.DealDamage(x.GetComponent<Health>());
            rayCaster.OnHitGO += (x) => hitMarker.HitMark();
            damageDealer.ReceiveScore += scoreKeeper.KeepScore;
        }
    }




}


