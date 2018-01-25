using UnityEngine;
using UnityEngine.AI;
namespace Infrastructure
{

    public class ConstructionJob : Job
    {
        public int Invalid;
        public TransportationJob transportationJob;
        public float WorkLeft = 10;
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

        public override void OnComplete()
        {
            cubeColors.SetBuild(gameObject);
            NavmeshLinkAdder.AddLinks(gameObject, gameObject.transform.localScale, nvOffset);
            navMesh.UpdateNavMesh(navMesh.navMeshData);
            gameObject.layer = 9;
            constructionStatus = ConstructionStatus.COMPLETE;
        }

        public override float CalculateUtility(AIUnit aiUnit)
        {
            return 0;
        }

        public override void Execute(AIUnit aiUnit, float Period)
        {
            throw new System.NotImplementedException();
        }
    }

    public enum ConstructionStatus
    {
        COMPLETE,INPROGRESS
    }

  
}
