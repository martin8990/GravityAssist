using UnityEngine;
namespace Infrastructure
{
    public class UseEffectPlayer : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip clip;
        public ParticleSystem ps;
        public void PlayUseEffect()
        {
            audioSource.PlayOneShot(clip);
            ps.Play(true);
        }
    }




}


