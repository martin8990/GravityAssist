using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
public class ClassGenerator : MonoBehaviour {
    public List<string> directories = new List<string>();
    public List<ComponentPrefab> componentLines = new List<ComponentPrefab>();

    public void AddDirectory(string dir)
    {
        directories.Add(dir);
    }
    public void RemoveDirectory(string dir)
    {
        directories.Remove(dir); 
    }
  
    


}
[System.Serializable]
public class ComponentPrefab
{
    public string origin;
    public List<string> lines;
}
