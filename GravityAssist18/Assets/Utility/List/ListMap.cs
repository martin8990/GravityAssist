using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Utility
{
    public static class ListMap
    {
        public static List<Result> Map<Result, Input1>(this List<Input1> in1, Func<Input1, Result> func)
        {
            var result = new List<Result>();
            for (int i = 0; i < in1.Count; i++)
            {
                result.Add(func(in1[i]));
            }
            return result;
        }
        public static List<Result> Map2<Result, Input1, Input2>(List<Input1> in1, List<Input2> in2, Func<Input1,Input2, Result> func)
        {
            var result = new List<Result>();
            for (int i = 0; i < in1.Count; i++)
            {
                result.Add(func(in1[i],in2[i]));
            }
            return result;
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
    }


}
