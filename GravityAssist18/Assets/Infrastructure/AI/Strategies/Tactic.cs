
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public abstract class Tactic : MonoBehaviour
    {

        public abstract float CalculateUtility();
        public abstract IEnumerator Execute(int Period);
    }

}


