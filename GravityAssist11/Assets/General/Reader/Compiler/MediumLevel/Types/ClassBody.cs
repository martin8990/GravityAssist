using System.Collections.Generic;
[System.Serializable]
public class ClassBody
{
    public string name;
    public List<string> Generics;
    public List<AnsestorToken> Ancestors;
    public List<string> Symbols;
    public List<string> Modifiers;
    public List<ClassBody> classBodies;
    public List<StructBody> stuctBodies;
    public List<MethodBody> methodBodies;
    public List<PropertyBody> propertyBodies;
    public List<AtributeBody> atributeBodies;
}
