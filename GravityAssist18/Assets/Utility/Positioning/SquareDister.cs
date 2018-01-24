using UnityEngine;


namespace Utility
{
    public static class SquareDister
    {
        public static float SquareDist2(this Vector3 me, Vector3 dest)
        {
       

            return Mathf.Pow(dest.x - me.x, 2) + Mathf.Pow(dest.z  - me.z, 2);   
        }
    }
}
