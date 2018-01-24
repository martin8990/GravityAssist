using UnityEngine;
namespace Infrastructure
{
    public class IdleAI : AIModule
    {
        public override void Execute(float period)
        {
            Debug.Log("Idle");
        }
    }
}




