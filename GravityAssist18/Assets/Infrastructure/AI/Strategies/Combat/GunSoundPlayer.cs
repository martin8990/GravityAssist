
using UnityEngine;
using System.Collections;
namespace Infrastructure
{
    public class GunSoundPlayer : MonoBehaviour
    {
        public float intervalTime = 0.1f;
        AudioSource audioSource;

        private void Start()
        {
             audioSource = GetComponent<AudioSource>();
            StartCoroutine(playSound());
        }
        IEnumerator playSound()
        {
            audioSource.Play();
            yield return new WaitForSeconds(intervalTime);
            StartCoroutine(playSound());
        }


    }


}


