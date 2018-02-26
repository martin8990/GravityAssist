using System;
using System.Collections.Generic;
using UnityEngine;
namespace Utility
{
    public class IntVector3
    {
        public int x;
        public int y;
        public int z;

        public IntVector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public IntVector3(Vector3 vec)
        {
            this.x = (int)vec.x;
            this.y = (int)vec.y;
            this.z = (int)vec.z;
        }
    }
}
