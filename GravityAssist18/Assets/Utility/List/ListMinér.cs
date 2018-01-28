using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public static class ListMinér
    {
        public static float ListMin(this List<float> list)
        {
            float minval = Mathf.Infinity;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < minval)
                {
                    minval = list[i];
                }
            }
            return minval;
        }
    }

}
