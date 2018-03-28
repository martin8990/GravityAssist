using UnityEngine;
using UnityEngine.UI;
namespace Infrastructure
{
    [RequireComponent(typeof(Health))]
    public class HealthIndicator : MonoBehaviour
    {
        public Image indicatorImage;
        Health health;
        private void Awake()
        {
            health = GetComponent<Health>();
            health.OnHealthChange += UpdateIndication;
        }
        public void UpdateIndication(float Health)
        {
            
            float alpha = 1f-Health/health.MaxHP;
            var c = indicatorImage.color;
            indicatorImage.color = new Color(c.r, c.g, c.b, alpha);
        }

    }
}






