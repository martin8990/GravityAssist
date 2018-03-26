using UnityEngine;

namespace Infrastructure
{
    public abstract class Tool : MonoBehaviour
    {
        public float range = 100f;
        public float interval = 0.1f;
        public Camera cam;
        public LayerMask TargetLayer;
        

        public GameObject hitMarker;

        public AudioSource audioSource;
        public AudioClip clip;
        public ParticleSystem useEffect;
        public ParticleSystem hitEffect;

        float t;
        bool hashit = false;
        public abstract void OnHit(GameObject target);


        private void Update()
        {           
            hashit = false;
            t += Time.deltaTime;
            if (Input.GetMouseButton(0) && t > interval)
            {
                t = 0;
                use();
            }
            hitMarker.SetActive(hashit);
        }
        public abstract void OnUse();

        public void use()
        {
            RaycastHit hit;
            //Debug.DrawRay(cam.transform.position, cam.transform.forward * range);
            OnUse();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range,TargetLayer))
            {

                var go = hit.collider.gameObject;
                hitEffect.transform.position = hit.point;
                hitEffect.Play();
                //  Debug.Log(go.name + " " + go.layer);
               
                    hashit = true;
                    OnHit(go);
               
            }
            audioSource.PlayOneShot(clip);
            useEffect.Play(true);
        }
    }    




}


