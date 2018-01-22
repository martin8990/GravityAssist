using System.Collections.Generic;
using UnityEngine;
using Domain;
using UnityEngine.AI;
using Utility;
namespace Infrastructure
{

    public class Pathfinder : MonoBehaviour
    {
        public Transform destination;
        public NavMeshAgent nvAgent;
        bool hasPath;

        private void Start()
        {
            nvAgent = this.GetComponent<NavMeshAgent>();
           
        }
        private void Update()
        {
            if (destination!=null && !hasPath)
            {

                FindPath();
            }
        }
        [Button]
        public void FindPath()
        {
            if (destination!=null)
            {
                nvAgent.SetDestination(destination.position);
                hasPath = true;
            }

        }
    }
}
