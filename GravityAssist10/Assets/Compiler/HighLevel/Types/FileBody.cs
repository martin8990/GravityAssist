using System.Collections.Generic;
[System.Serializable]
public class FileBody
{
    public List<string> UnidentifiedSymbols = new List<string>();
    public List<ClassBody> classBodies = new List<ClassBody>();
    public List<StructBody> structBodies = new List<StructBody>();
    public List<InterfaceBody> interfaceBodies = new List<InterfaceBody>();
    public List<EnumBody> enumBodies = new List<EnumBody>();
    public List<UsingStatement> usingStatements = new List<UsingStatement>();

}
