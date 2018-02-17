using System;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class Stockpile : Job
    {
        public int nMaterial = 10000;

        public override float CalculateUtility(AIUnit aiUnit)
        {
            return 0;
        }

        public override void Execute(AIUnit aiUnit, int Period)
        {
            throw new NotImplementedException();
        }
    }
}
