using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public static class ListMinér
    {
        public static int ListMin(this List<float> list)
        {
            float minval = Mathf.Infinity;
            int mindex = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < minval)
                {
                    minval = list[i];
                    mindex = i;
                }
            }
            return mindex;
        }
        public static int ListMax(this List<float> list)
        {
            float minval = -Mathf.Infinity;
            int mindex = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > minval)
                {
                    minval = list[i];
                    mindex = i;
                }
            }
            return mindex;
        }
    }

}
