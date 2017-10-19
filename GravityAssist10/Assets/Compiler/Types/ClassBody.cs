using System.Collections.Generic;
[System.Serializable]
public class ClassBody
{
    public string name;
    public List<string> Generics;
    public List<InterfaceToken> Interfaces;
    public List<string> Symbols;
    public List<string> Modifiers;
}

