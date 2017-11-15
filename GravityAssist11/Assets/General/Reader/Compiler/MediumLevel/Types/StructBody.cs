using System.Collections.Generic;
[System.Serializable]
public class StructBody
{
    public string name;
    public List<string> Generics;
    public List<AnsestorToken> Interfaces;
    public List<string> Symbols;
    public List<string> Modifiers;
}

