
using UnityEngine;
using UnityEngine.AI;

namespace Infrastructure
{
    public class AIUnitAnimator : MonoBehaviour
    {
        public Animator anim;
        public NavMeshAgent navMeshAgent;
        private void Update()
        {
            anim.SetFloat("speed_t", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        }
    }


}


