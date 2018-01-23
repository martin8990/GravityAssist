using UnityEngine;


namespace Utility
{
    public static class SquareDister
    {
        public static float SquareDist2(this Vector3 me, Vector3 dest)
        {
            return Mathf.Pow(me.x - dest.x, 2) + Mathf.Pow(me.z - dest.z, 2);   
        }
    }
}
