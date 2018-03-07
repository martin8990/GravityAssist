using Utility;
using UnityEngine;
using UnityEngine.AI;


public class PathFinder : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
