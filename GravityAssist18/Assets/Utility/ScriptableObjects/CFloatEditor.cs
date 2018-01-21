using UnityEngine;
using UnityEditor;

namespace Utility
{
    [CustomEditor(typeof(CFloat))]
    public class CFloatEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var myFloat = target as CFloat;
            if (GUILayout.Button("increase 1"))
            {
                myFloat.val += 1;                
            }
            if (GUILayout.Button("Decrease 1"))
            {
                myFloat.val -= 1;
            }
        }
    }
}
