using UnityEngine;
using UnityEditor;

namespace Utility
{
    [CustomEditor(typeof(CInt))]
    public class CIntEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var myInt = target as CInt;
            if (GUILayout.Button("increase 1"))
            {
                myInt.val += 1;
                EditorUtility.SetDirty(myInt);

            }
            if (GUILayout.Button("Decrease 1"))
            {
                myInt.val -= 1;
                EditorUtility.SetDirty(myInt);
            }
        }
    }
}
