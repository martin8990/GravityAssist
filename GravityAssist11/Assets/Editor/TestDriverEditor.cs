using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestDriver))]
public class TestDriverEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var TD = target as TestDriver;
        if (GUILayout.Button("Execute"))
        {
            TD.Reload();
        }
    }
}
