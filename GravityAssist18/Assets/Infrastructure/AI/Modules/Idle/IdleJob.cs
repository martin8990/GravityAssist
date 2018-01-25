using UnityEngine;
namespace Infrastructure
{
    public class IdleJob : Job
    {
        public float lazyness = 0.01f;
        public override float CalculateUtility(AIUnit aiUnit)
        {
            return lazyness;
        }

        public override void Execute(AIUnit aiUnit, float Period)
        {
            
        }

        public override void OnComplete()
        {
            
        }
    }
}




