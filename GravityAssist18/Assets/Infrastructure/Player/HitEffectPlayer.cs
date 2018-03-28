using UnityEngine;
namespace Infrastructure
{
    public class HitEffectPlayer : MonoBehaviour
    {
        public ParticleSystem hitEffect;
        public AudioClip clip;
        public AudioSource source;
       
        public void Hit(Vector3 position)
        {
            transform.position = position;
            hitEffect.Play(true);
            if (source!=null)
            {
                source.PlayOneShot(clip); 
            }
        }
    }




}


