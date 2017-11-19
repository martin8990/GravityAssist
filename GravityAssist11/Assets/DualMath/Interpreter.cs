using System;
using System.Collections.Generic;
using UnityEngine;
public static class Interpreter
{
    public static Dictionary<string, Operation> SymbolDict = new Dictionary<string, Operation>();
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
        OperationSorter.GetOperations(tokens);

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

public static class OperationSorter
{

    public static void GetOperations(List<string> OperationTokens)
    {

        List<Operation> operations = new List<Operation>();
    
        for (int i = 0; i < OperationTokens.Count; i++)
        {
            var op = Numerics.Find(OperationTokens[i]);
            if (op!=null)
            {
                operations.Add(op);
            }
        }
        
        Operators.ClaimChildren(operations,2);
        Debug.Log("Result = " + operations[0].Calculate(operations[0]));
        Debug.Log(operations.Count);


    }
}





