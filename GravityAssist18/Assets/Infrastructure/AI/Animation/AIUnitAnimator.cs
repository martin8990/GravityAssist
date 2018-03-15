
using UnityEngine;
using UnityEngine.AI;

namespace Infrastructure
{
    public class AIUnitAnimator : MonoBehaviour
    {
        Animator anim;
        NavMeshAgent navMeshAgent;
        private void Start()
        {
            anim = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            anim.SetFloat("speed_t", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        }
    }


}


