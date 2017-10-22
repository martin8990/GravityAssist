using System.Collections.Generic;
using UnityEngine;

public static class NameFinder
{
    public static string Operate(int KeyWordIndex, List<string> symbols)
    {
        var name = symbols[KeyWordIndex+1];
        symbols[KeyWordIndex + 1] = null;
        return name;
    }
}

public static class MethodNameFinder
{
    public static string Operate(List<string> symbols, int index)
    {
        while (symbols[index] != "(")
        {
 
            index--;
        }
        index--;
        while (symbols[index] == null)
        {
            index--;
        }
        var name = symbols[index];
        symbols[index] = null;
        return name;


    }
}


