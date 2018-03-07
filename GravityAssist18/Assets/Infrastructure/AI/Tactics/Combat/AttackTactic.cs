using System;

namespace Infrastructure
{
    public class AttackTactic : Tactic
    {
        public int EnemyLayer;
        Func<float> GetCombatRating;

        public override float CalculateUtility(AIUnit aiUnit)
        {
            if (GetCombatRating() > 0)
            {

            }            
        }

        public override void Execute(AIUnit aiUnit, int Period)
        {
            throw new System.NotImplementedException();
        }
    }
}


