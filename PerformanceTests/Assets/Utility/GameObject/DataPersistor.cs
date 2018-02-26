using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Utility
{
    [ExecuteInEditMode]
    public class DataPersistor : MonoBehaviour
    {
        const string basePath = @"C:\Users\marti\Documents\Unity\GravityAssist\GravityAssist18\Assets\Design\MonoSaves\";
        public List<MonoBehaviour> AutoSaving;

        private void Awake()
        {
            if (!Application.isPlaying)
            {
                AutoSaving.Iter((x) => Load(x));
            }
        }
        public void OnApplicationQuit()
        {
            AutoSaving.Iter((x) => Save(x));    
        }

        public static void Save(Object ext)
        {
            string jsonString = JsonUtility.ToJson(ext);
            File.WriteAllText(basePath + ext.name + ".txt", jsonString);

        }
        public static void Load(Object ext)
        {
            string jsonString = File.ReadAllText(basePath + ext.name + ".txt");
            JsonUtility.FromJsonOverwrite(jsonString, ext);            
        }
    }


}
