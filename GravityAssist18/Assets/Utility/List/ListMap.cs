﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ListMap
    {
        public static List<Result> Map<Result, Input1>(List<Input1> in1, Func<Input1, Result> func)
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
}
