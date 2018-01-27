//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(WorldGenControl))]
//public class WorldGenControlEditor : Editor {

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        WorldGenControl CTRL = (WorldGenControl)target;

//        if (GUILayout.Button("Generate Mesh"))
//        {
//            CTRL.planeMeshGenerator.GeneratePlanes();
//        }
//        if (GUILayout.Button("Generate Vonoroi"))
//        {
//            CTRL.vonoroiGenerator.GenerateVoronoi();
//        }
//        if (GUILayout.Button("Sample Vonoroi"))
//        {
//            CTRL.heightMapper.SampleVonoroi();
//        }
//        if (GUILayout.Button("Map Vonoroi"))
//        {
//            CTRL.vonoroiMapper.MapVoronoi();
//        }
//    }

//}
