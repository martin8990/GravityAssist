﻿using System;

namespace Utility
{


    public static class ArrayMap
    {
        public static Result[] Map<Result, Input1>(this Input1[] in1,  Func<Input1, Result> func)
        {
            var result = new Result[in1.Length];
            for (int i = 0; i < in1.Length; i++)
            {
                result[i] = func(in1[i]);
            }
            return result;
        }

        public static Result[] Map2D1D<Result, Input1>(this Input1[,] in1, Func<Input1, Result> func)
        {
            var result = new Result[in1.GetLength(0)*in1.GetLength(1)];
            for (int x = 0; x < in1.GetLength(0); x++)
            {
                for (int y = 0; y < in1.GetLength(1); y++)
                {
                    result[x + y * in1.GetLength(0)] = func(in1[x,y]);
                }

            }
            return result;
        }
        public static Result[] Map2<Result,Input1,Input2>(Input1[] in1,Input2[] in2, Func<Input1,Input2,Result> func)
        {
            var result = new Result[in1.Length];
            for (int i = 0; i < in1.Length; i++)
            {
                result[i] = func(in1[i], in2[i]);
            }
            return result;
        }
    }
}
