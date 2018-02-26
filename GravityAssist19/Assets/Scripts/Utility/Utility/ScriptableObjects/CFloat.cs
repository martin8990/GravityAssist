using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Constants/CFloat", fileName = "CFloat")]
    public class CFloat : ScriptableObject, ExecutorEditable
    {
        public float val;
        
        public static implicit operator float(CFloat cFloat)
        {
            return cFloat.val;
        }
    }

    public interface ExecutorEditable
    {
    }
}
