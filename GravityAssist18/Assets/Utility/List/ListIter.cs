using System;
using System.Collections.Generic;


namespace Utility
{
    public static class ListIter
    {
        public static void Iter<T>(this List<T> list, Action<T> action)
        {
             for (int x = 0; x < list.Count; x++)
            {

                action(list[x]);

            }
        }
        public static void IterR<T>(this List<T> list, Action<T> action)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                action(list[i]);
            }
        }
    }


}
