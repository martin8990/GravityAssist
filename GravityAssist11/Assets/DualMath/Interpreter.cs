using System;
using System.Collections.Generic;
using UnityEngine;
public static class Interpreter
{
    public static Dictionary<string, token> SymbolDict = new Dictionary<string, token>();
    static bool error = false;

    public static void InterpretTokens(List<string> tokens)
    {
        error = false;
        string assignment = Assignment(tokens);

        bool isAssignment = false;
        if (assignment.Length > 0)
        {
            isAssignment = true;
        }
        var operation =  OperationPlanner.Plan(tokens);
        if (operation!=null)
        {
            OperationCalculator.Calc(operation);
        }
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
    public static token KnownSymbol(int i, List<string> tokens)
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





