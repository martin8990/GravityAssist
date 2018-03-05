using Utility;
using UnityEngine;
using UnityEngine.AI;
//namespace Infrastructure
//{
//    public class AITest : MonoBehaviourExt
//    {
//        public AIUnit AI;

//        [Button]
//        public void RouteToMe()
//        {
//            AI.navMeshAgent.destination = transform.position;
//        }
//    }

//}

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
