using System.Collections.Generic;
using UnityEngine;
public static class StructExtracter
{
    public static List<StructBody> Operate(List<string> Symbols)
    {
        var structBodies = new List<StructBody>();
        var indices = KeyWordFinder.FindKeyWords(Symbols, "struct");
        var ModifierTypes = new List<string> { "public", "private" ,"unsafe"};        
        foreach (var index in indices)
        {
            var structBody = new StructBody();
            structBody.name = NameFinder.Operate(index, Symbols);
            structBody.Generics = GenericsFinder.Operate(index, Symbols);
            structBody.Interfaces = AnsestorExtracter.operate(index, Symbols);
            structBody.Modifiers = ModifierFinder.Operate(ModifierTypes, Symbols, index);
            structBody.Symbols = BodyExtractor.Operate(index, Symbols);

            structBodies.Add(structBody);
        }

        SymbolCleaner.Operate(Symbols);
       
        return structBodies;
    }
}

