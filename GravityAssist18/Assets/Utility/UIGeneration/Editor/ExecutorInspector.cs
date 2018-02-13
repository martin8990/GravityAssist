﻿using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections.Generic;
using System.IO;


namespace Utility
{
    [CustomEditor(typeof(MonoBehaviourExt), true)]
    public class MonobehaviourInspector : Editor
    {
        bool setup = false;
        List<MethodInfo> methods;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
     
            if (methods == null)
            {
                methods = new List<MethodInfo>();
                var methds = target.GetType().GetMethods();
                foreach (var method in methds)
                {
                    var GoodMethod = method.GetCustomAttribute<ButtonAttribute>();
                    if (GoodMethod!=null)
                    {
                        methods.Add(method);
                    }
                }
            }
            foreach (var method in methods)
            {
                if (GUILayout.Button(method.Name))
                {
                    method.Invoke(target,null);
                }
            }
            if (GUILayout.Button("Save"))
            {
                DataPersistor.Save(target);
            }
            if (GUILayout.Button("Load"))
            {
                var jsonString = DataPersistor.Load(target);
                JsonUtility.FromJsonOverwrite(jsonString, target);
            }



        }

    }

    public static class CFloatUI
    {
        public static void Show(CFloat val, string name)
        {
            if (val == null)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(name);
                if (GUILayout.Button("Find"))
                {
                    Debug.Log("Find Asset");
                }

                if (GUILayout.Button("Create"))
                {
                    Debug.Log("Create asset");
                }
                EditorGUILayout.EndHorizontal();


            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(name);
                val.val = EditorGUILayout.FloatField(val.val);
                EditorGUILayout.EndHorizontal();


            }
        }
           
    }

}