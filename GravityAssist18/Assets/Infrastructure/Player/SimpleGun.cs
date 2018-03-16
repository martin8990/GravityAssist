using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class SimpleGun : MonoBehaviour
    {
        public float Range = 100;
        public int DMG = 10;
        public float firingRate;
        public Camera cam;
        public int enemyLayer;
        public GameObject hitMarker;

        public ParticleSystem hitEffect;

        public AudioSource audioSource;
        public AudioClip clip;
        public ParticleSystem system;
        public Transform hipTransform;
        public Transform ADSTransform;

        public event Action<int> OnReceiveScore;

        float t;
        bool hashit = false;
        private void Update()
        {
            hashit = false;
            t += Time.deltaTime;
            if (Input.GetMouseButton(0) && t > firingRate)
            {
                t = 0;
                Shoot();
            }
            if (Input.GetMouseButton(1))
            {
                transform.position = ADSTransform.position;
                transform.rotation = ADSTransform.rotation;
            }
            else
            {
                transform.position = hipTransform.position;
                transform.rotation = hipTransform.rotation;
            }
            hitMarker.SetActive(hashit);  

        }
        void Shoot()
        {

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range))
            {

                var go = hit.collider.gameObject;
                hitEffect.transform.position = hit.point;
                hitEffect.Play();
              //  Debug.Log(go.name + " " + go.layer);
                if (go.layer == enemyLayer)
                {
                    Debug.Log("Hit");
                    hashit = true;
                    var enemyHealth = go.GetComponent<Health>();
                    enemyHealth.TakeDamage(DMG,OnReceiveScore);
                }
            }
            audioSource.PlayOneShot(clip);
            system.Play(true);
        }
    }




}


