using System.Collections.Generic;
using UnityEngine;

public static class FileBodyFromSymbols
{
    public static List<FileBody> Operate(List<SymbolsPerFile> input)
    {
        List<FileBody> fileBodies = new List<FileBody>();
        foreach (var file in input)
        {
            var body = new FileBody();
            body.UnidentifiedSymbols = file.Symbols;
            body.structBodies = StructExtracter.Operate(body.UnidentifiedSymbols);
            body.classBodies = ClassExtracter.Operate(body.UnidentifiedSymbols);
            body.usingStatements = UsingStatementExtracter.Operate(body.UnidentifiedSymbols);
            body.interfaceBodies = InterfaceExtracter.Operate(body.UnidentifiedSymbols);
            body.enumBodies = EnumExtracter.Operate(body.UnidentifiedSymbols);

            fileBodies.Add(body);
      
        }
        return fileBodies;
    }    
}
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

[System.Serializable]
public class EnumBody
{
    public string name;
    public List<string> Modifiers;
    public List<string> Symbols;
}
