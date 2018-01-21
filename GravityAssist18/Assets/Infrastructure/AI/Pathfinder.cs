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

        private void Start()
        {
            nvAgent = this.GetComponent<NavMeshAgent>();
            FindPath();
        }

        [Button]
        public void FindPath()
        {
            nvAgent.SetDestination(destination.position);   
        }
    }
}
