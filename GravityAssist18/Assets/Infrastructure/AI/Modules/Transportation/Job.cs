
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public abstract class Job : MonoBehaviour 
    {
        public Color DebugColor;
        public int nUnitsAssigned = 0;
        public CInt aiLayer;

        public List<AIUnit> inRange = new List<AIUnit>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == aiLayer)
            {
                inRange.Add(other.GetComponent<AIUnit>());
            }           
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == aiLayer)
            {
                inRange.Remove(other.GetComponent<AIUnit>());
            }
        }
        public bool InRange(AIUnit unit)
        {
            return inRange.Contains(unit);
        }

        public float CoopPenalty = 0.5f;

        public int CoopMax = 2;

        public abstract float CalculateUtility(AIUnit aiUnit);
        public abstract void Execute(AIUnit aiUnit, int Period);
    }

}


