using UnityEngine;

namespace Infrastructure
{

    public class PositionChecker : MonoBehaviour
    {
        public int[] CollisionLayers;

        public int Invalid;
        private void OnTriggerEnter(Collider other)
        {

            foreach (var layer in CollisionLayers)
            {
                if (other.gameObject.layer == layer)
                {
                    Invalid++;

                }
            }            
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var layer in CollisionLayers)
            {
                if (other.gameObject.layer == layer)
                {
                    Invalid--;

                }
            }
        }
    }




}
