using UnityEngine;

namespace Infrastructure
{
    public class TurretWeapon : MonoBehaviour
    {
        public int damage = 1;
        public float fireRate = 0.5f;
        public float turnSpeed = 2;
        [HideInInspector]
        public Health target;
        float t = 0;
        public AudioSource TurretShotSRC;
        public AudioClip TurretShot;

        private void Update()
        {
            t += Time.deltaTime;
            if (target != null)
            {
                var relPos = target.transform.position - transform.position;
                var rotation = Quaternion.LookRotation(relPos);
                var current = transform.localRotation;
                transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turnSpeed);
                
                if (t > fireRate + Random.Range(0f,fireRate))
                {
                    t = 0;
                    target.TakeDamage(damage, (x) => { });
                    TurretShotSRC.PlayOneShot(TurretShot);
                }
            }
        }


    }


}


