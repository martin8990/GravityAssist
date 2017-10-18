using System.Collections.Generic;
using UnityEngine;

public static class FileBodyFromSymbols
{
    public static List<Body> Operate(List<SymbolsPerFile> input,BodyType fileBodytype)
    {
        List<Body> fileBodies = new List<Body>();
        foreach (var file in input)
        {
            var body = new Body();
            body.bodyType = fileBodytype;
            body.symbols = file.Symbols; 
            fileBodies.Add(body);            
        }
        return fileBodies;
    }    
}