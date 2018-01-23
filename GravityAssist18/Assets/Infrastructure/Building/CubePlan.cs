using UnityEngine;
namespace Infrastructure
{
    public class CubePlan : MonoBehaviour
    {
        public float WorkLeft = 10;
        public int Invalid;
        public int CubeLayer = 8;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == CubeLayer)
            {
                Invalid++;
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == CubeLayer)
            {
                Invalid--;
            }
        }

    }

    
    

}
