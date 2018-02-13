using System.IO;
using UnityEngine;

namespace Utility
{
    public static class DataPersistor
    {
        const string basePath = @"C:\Users\marti\Documents\Unity\GravityAssist\GravityAssist18\Assets\Design\MonoSaves\";

        public static void Save(Object ext)
        {
            string jsonString = JsonUtility.ToJson(ext);
            File.WriteAllText(basePath + ext.name + ".txt", jsonString);

        }
        public static string Load(Object ext)
        {
            string jsonString = File.ReadAllText(basePath + ext.name + ".txt");
            return jsonString;
            
        }
    }
}
