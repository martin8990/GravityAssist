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
    public List<InterfaceBodies> interfaceBodies = new List<InterfaceBodies>();
    public List<EnumBodies> enumBodies = new List<EnumBodies>();
    public List<UsingStatement> usingStatements = new List<UsingStatement>();

}

[System.Serializable]
public class UsingStatement
{
    public List<string> Addres;
}
[System.Serializable]
public class InterfaceBodies
{

}
[System.Serializable]
public class EnumBodies
{

}
