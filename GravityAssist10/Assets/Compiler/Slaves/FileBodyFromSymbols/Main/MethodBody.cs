using System.Collections.Generic;
[System.Serializable]
public class MethodBody
{
    public string name;
    public List<string> modifiers;
    public List<Argument> arguments;
    public List<string> symbols;
    public List<string> Generics;
    public string returnType;
}

