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
