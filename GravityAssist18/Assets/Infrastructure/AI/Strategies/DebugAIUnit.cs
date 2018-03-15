
using UnityEngine;

namespace Infrastructure
{
    [RequireComponent(typeof(DebugStrategy))]
    public class DebugAIUnit : AIUnit
    {
        DebugStrategy debugStrategy;
        private void Awake()
        {
            debugStrategy = GetComponent<DebugStrategy>();
            strategies.Add(debugStrategy);
        }

    }




}


