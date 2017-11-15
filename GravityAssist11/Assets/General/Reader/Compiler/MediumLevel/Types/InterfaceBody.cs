using System.Collections.Generic;
[System.Serializable]
public class InterfaceBody
{
    public string name;
    public List<string> Generics;
    public List<AnsestorToken> Ancestors;
    public List<string> Symbols;
    public List<string> Modifiers;
}
