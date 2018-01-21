using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Constants/CInt", fileName = "CInt")]
    public class CInt: ScriptableObject
    {
        public int val;
        public static implicit operator int(CInt cInt)
        {
            return cInt.val;
        }
    }
}
