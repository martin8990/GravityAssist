using UnityEngine;
namespace Infrastructure
{
    public class HitMarker : MonoBehaviour
    {
        public GameObject hitMarker;
        public float markTime = 0.2f;
        float hitTime;

        public void HitMark()
        {
            hitTime = Time.time;
        }
        private void Update()
        {
            float t = Time.time;
            if (t - hitTime < markTime)
            {
                hitMarker.SetActive(true);
            }
            else
            {
                hitMarker.SetActive(false);

            }            
        }


    }




}


