
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public abstract class Tactic : MonoBehaviour
    {

        public abstract float CalculateUtility(AIUnit aiUnit);
        public abstract IEnumerator Execute(AIUnit aiUnit, int Period);
    }

}


