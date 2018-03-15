using UnityEngine;
namespace Infrastructure
{
    [RequireComponent(typeof(DebugTactic))]
    public class DebugStrategy : Strategy
    {
        DebugTactic debugTactic;
        private void Awake()
        {
            debugTactic = GetComponent<DebugTactic>();
            tactics.Add(debugTactic);
        }

        public override float GetStrategyUtility()
        {
            return 0.01f;
        }
    }




}


