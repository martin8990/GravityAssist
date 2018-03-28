using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    [RequireComponent(typeof(TimedMouseTriggerer))]
    [RequireComponent(typeof(CameraPenetrativeRayCaster))]
    [RequireComponent(typeof(UseEffectPlayer))]
    [RequireComponent(typeof(HitMarker))]
    [RequireComponent(typeof(DamageDealer))]
    [RequireComponent(typeof(ScoreKeeper))]
    public class Gun : MonoBehaviour
    {
        public HitEffectPlayer hitEffectPlayer;

        TimedMouseTriggerer timedTrigger;
        CameraPenetrativeRayCaster rayCaster;
        HitMarker hitMarker;
        UseEffectPlayer useEffectPlayer;
        DamageDealer damageDealer;
        ScoreKeeper scoreKeeper;
        private void Awake()
        {
            timedTrigger = GetComponent<TimedMouseTriggerer>();
            rayCaster = GetComponent<CameraPenetrativeRayCaster>();
            hitMarker = GetComponent<HitMarker>();
            useEffectPlayer = GetComponent<UseEffectPlayer>();
            damageDealer = GetComponent<DamageDealer>();
            scoreKeeper = GetComponent<ScoreKeeper>();

            timedTrigger.OnTrigger += rayCaster.RaycastPenetratively;
            timedTrigger.OnTrigger += useEffectPlayer.PlayUseEffect;
            rayCaster.OnHitGO += (x) => hitEffectPlayer.Hit(x.transform.position);
            rayCaster.OnHitGO += (x) => damageDealer.DealDamage(x.GetComponent<Health>());
            rayCaster.OnHitGO += (x) => hitMarker.HitMark();
            damageDealer.ReceiveScore += scoreKeeper.KeepScore;            
        }
    }




}


