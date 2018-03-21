using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Constants/CIntArr", fileName = "CIntArr")]
    public class CIntArr: ScriptableObject
    {
        public int[] val;
        public static implicit operator int[](CIntArr cIntArr)
        {
            return cIntArr.val;
        }
          }
}
