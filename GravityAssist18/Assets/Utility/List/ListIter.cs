using System;
using System.Collections.Generic;


namespace Utility
{
    public static class MinMax
    {
        public static T Min<T>(this List<T> list, Func< T,float> func)
        {
            float min = float.MaxValue;
            T Best = default(T);
            for (int i = 0; i < list.Count; i++)
            {
                var val = func(list[i]);
                if (val < min)
                {
                    min = val;
                    Best = list[i];
                }
            }
            return Best;
        }
        public static T Max<T>(this List<T> list, Func<T, float> func)
        {
            float min = float.MinValue;
            T Best = default(T);
            for (int i = 0; i < list.Count; i++)
            {
                var val = func(list[i]);
                if (val > min)
                {
                    min = val;
                    Best = list[i];
                }
            }
            return Best;
        }
    }

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
