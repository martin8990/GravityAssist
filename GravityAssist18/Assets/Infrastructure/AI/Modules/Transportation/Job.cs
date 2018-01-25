
using UnityEngine;

namespace Infrastructure
{
    public abstract class Job : MonoBehaviour 
    {
        public Color DebugColor;
        public abstract float CalculateUtility(AIUnit aiUnit);
        public abstract void Execute(AIUnit aiUnit, float Period);
        public abstract void OnComplete();
    }

}


