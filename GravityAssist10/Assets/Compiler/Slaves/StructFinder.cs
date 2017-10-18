using System.Collections.Generic;
using UnityEngine;
public static class StructExtracter
{
    public static List<StructBody> Operate(List<string> Symbols)
    {
        var structBodies = new List<StructBody>();
        var indices = KeyWordFinder.FindKeyWords(Symbols, "struct");
                
        foreach (var index in indices)
        {
            var structBody = new StructBody();
            structBody.name = NameFinder.Operate(index, Symbols);
            structBody.Symbols = BodyGetter.Operate(index, Symbols);
            structBody.Generics = GenericsFinder.Operate(index, Symbols);
            structBody.Interfaces = InterfaceFinder.operate(index, Symbols); 
            

            structBodies.Add(structBody);
        }

        SymbolCleaner.Operate(Symbols);
       
        return structBodies;
    }
}
