
using UnityEngine;
using Utility;
using UnityEngine.AI;

namespace Infrastructure
{
    public abstract class AIModule : MonoBehaviour
    {
        
        public NavMeshAgent navMeshAgent;
        public Color color;
        [HideInInspector]
        public bool currentActivvity;
        public UtilityCalculation utility;
        public CFloat DestinationReachedMargin;

        public void init( NavMeshAgent _navMeshAgent)
        {
            navMeshAgent = _navMeshAgent;
        }
                
        public abstract void Execute(float period);
    }
    
    

}


