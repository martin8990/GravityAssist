using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Compiler))]
public class CompilerEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var compiler = target as Compiler;
        if (GUILayout.Button("Compile"))
        {
            compiler.Compile();
        }
    }
}
