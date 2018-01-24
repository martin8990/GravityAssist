using UnityEngine;
namespace Infrastructure
{

    public class ConstructionPlan : MonoBehaviour
    {
        public float WorkLeft = 10;
        public float Material = 0;
        public int Invalid;
        public int CubeLayer = 8;
        public ConstructionStatus constructionStatus = ConstructionStatus.INPROGRESS;
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

    public enum ConstructionStatus
    {
        COMPLETE,DAMAGED,INPROGRESS
    }

    
    

}
