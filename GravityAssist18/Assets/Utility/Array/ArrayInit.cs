using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{

    public static class ArrayInit
    {
        public static T[] InitEXT<T>(this T[] array, Func<T> initer)
        {

            for (int y = 0; y < array.Length; y++)
            {
                array[y] = initer();
            }
            return array;

        }

        public static T[] Init<T>(int size, Func<T> initer)
        {
            T[] arr = new T[size];
            for (int y = 0; y < size; y++)
            {
                arr[size] = initer();
            }
            return arr;

        }
        public static T[] iInit<T>(int size, Func<int,T> initer)
        {
            T[] arr = new T[size];
            for (int y = 0; y < size; y++)
            {
                arr[size] = initer(y);
            }
            return arr;

        }


        public static T[,] Init2D<T>(int size1, int size2, Func<T> initer)
        {
            T[,] arr = new T[size1, size2];
            for (int x = 0; x < size1; x++)
            {
                for (int y = 0; y < size2; y++)
                {
                    arr[x, y] = initer();
                }
            }
            return arr;

        }
        public static T[,] iInit2D<T>(int size1, int size2, Func<int,int,T> initer)
        {
            T[,] arr = new T[size1, size2];
            for (int x = 0; x < size1; x++)
            {
                for (int y = 0; y < size2; y++)
                {
                    arr[x, y] = initer(x,y);
                }
            }
            return arr;

        }
    }
}
