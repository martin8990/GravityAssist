using System;
using System.Collections.Generic;

namespace Utility
{
    public static class ArrayIter
    {
        public static void Iter2D<T>(this T[,] arr, Action<T> action)
        {

            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                        action(arr[x, y]);
                    
                }
            }
        }
        public static void Iteri2D_<T>(this T[,] arr, Action<int, int, T> action)
        {
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {

                    
                        action(x, y, arr[x, y]);
                    
                }
            }
        }
        public static void Iteri2D<T>(T[,] arr, Action<int, int, T>[] actions)
        {
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    foreach (var action in actions)
                    {
                        action(x, y, arr[x, y]);
                    }
                }
            }
        }

        public static void Iter<T>(this T[] arr, Action<T> action)
        {

            for (int x = 0; x < arr.GetLength(0); x++)
            {

                    action(arr[x]);

            }
        }
        public static void Iteri<T>(this T[] arr, Action<int,T> action)
        {

            for (int x = 0; x < arr.GetLength(0); x++)
            {

                action(x,arr[x]);

            }
        }


    }

  
}
