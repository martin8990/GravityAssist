using System;
using System.Collections.Generic;
using UnityEngine;
public static class Interpreter
{
    public static Dictionary<string, Operation> SymbolDict = new Dictionary<string, Operation>();
    static bool error = false;

    public static float InterpretTokens(List<string> tokens)
    {
        error = false;
        string assignment = Assignment(tokens);

        bool isAssignment = false;
        if (assignment.Length > 0)
        {
            isAssignment = true;
        }
        var result =  Calculator.Calculate(tokens);
        return result;
    }

    public static string Assignment(List<string> tokens)
    {
        if (tokens.Count > 1 && tokens[1] == "=")
        {
            if (KnownSymbol(0, tokens) != null)
            {
                ThrowError("Value already assigned");
                return "";
            }
            else
            {
                return tokens[0];
            }
        }
        else
        {
            return "";
        }
    }
    public static Operation KnownSymbol(int i, List<string> tokens)
    {
        if (SymbolDict.ContainsKey(tokens[i]))
        {
            return SymbolDict[tokens[i]];
        }
        else
        {
            return null;
        }
    }
    public static void ThrowError(string Error)
    {
        Debug.Log(Error);
        error = true;
    }
}





