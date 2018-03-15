using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Constants/CString", fileName = "CString")]
    public class CString : ScriptableObject
    {
        public string val;
        public static implicit operator string(CString cString)
        {
            return cString.val;
        }
    }


}
