
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public abstract class Tactic : MonoBehaviour
    {
        public Color DebugColor;
        public int nUnitsAssigned = 0;
        public float CoopPenalty = 0.5f;
        public int CoopMax = 2;

        public abstract float CalculateUtility(AIUnit aiUnit);
        public abstract void Execute(AIUnit aiUnit, int Period);
    }

}


