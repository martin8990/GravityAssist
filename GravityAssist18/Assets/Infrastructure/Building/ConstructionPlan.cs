using UnityEngine;
using UnityEngine.AI;
namespace Infrastructure
{

    public class ConstructionPlan : MonoBehaviour
    {
        public float WorkLeft = 10;
        public float Material = 0;
        public int Invalid;
        public LayerMask CTORLayers = 8;
        public float nvOffset = 0.5f;
        public LayerMask ConstructionLayer;

        public ConstructionColors cubeColors;
        public ConstructionStatus constructionStatus = ConstructionStatus.INPROGRESS;
        [HideInInspector]
        public NavMeshSurface navMesh;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == CTORLayers)
            {
                Invalid++;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == CTORLayers)
            {
                Invalid--;
            }
        }

        public void onComplete()
        {
            cubeColors.SetBuild(gameObject);
            NavmeshLinkAdder.AddLinks(gameObject, gameObject.transform.localScale, nvOffset);
            navMesh.UpdateNavMesh(navMesh.navMeshData);
            gameObject.layer = 9;
        }
                

    }

    public enum ConstructionStatus
    {
        COMPLETE,DAMAGED,INPROGRESS
    }

    
    

}
