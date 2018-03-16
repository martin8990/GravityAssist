using UnityEngine;

namespace Infrastructure
{
    [RequireComponent(typeof(SimpleAttack))]
    public class SimpleCombat : Strategy
    {
        SimpleAttack simpleAttack;
        private void Awake()
        {
            simpleAttack = GetComponent<SimpleAttack>();
            tactics.Add(simpleAttack);
        }
        public override float GetStrategyUtility()
        {
           return 1;
        }
    }


}


