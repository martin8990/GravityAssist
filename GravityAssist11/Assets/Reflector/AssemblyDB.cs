using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AssemblyDB : ScriptableObject {
    public List<AssemblyBoi> AssemblyBois = new List<AssemblyBoi>();
    
}
[System.Serializable]
public class AssemblyBoi
{
    public string name;
    public List<TypeBoi> typeBois;
}
