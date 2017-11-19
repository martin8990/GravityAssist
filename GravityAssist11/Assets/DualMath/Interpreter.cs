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
        
        PrioOne.ClaimChildren(operations);
        Debug.Log("Result = " + operations[0].Calculate());
        Debug.Log(operations.Count);


    }
}

public abstract class Operation
{
    public List<Operation> Children = new List<Operation>();
    public Operation parent;
    public int prio;
    public abstract float Calculate();
    
}


public class Numerics:Operation
{

    float value;

    public Numerics(float value)
    {
        this.value = value;
        this.prio = 0;
    }

    public static Operation Find(string token)
    {
        float n;
        bool isNumeric = float.TryParse(token, out n);
        if (isNumeric)
        {
            
            var Operation = new Numerics(n);
            return Operation;
        }
        else
        {
            return PrioOne.Find(token);
        }

    }

    public override float Calculate()
    {
        return value;
    }
}

public class PrioOne : Operation
{
    public PrioOne()
    {
        this.prio = 1;
    }

    public static Operation Find(string Token)
    {
        if (Token == "+")
        {
            var operation = new PrioOne();
            return operation;
        }
        else
        {
            return null;
        }
    }
    public static void ClaimChildren(List<Operation> ops)
    {
     
        if (ops.Count>2)
        {
            for (int i = 1; i < ops.Count - 1; i++)
            {
                if (ops[i].prio == 1)
                {
                    ops[i].Children.Add(ops[i - 1]);
                    ops[i].Children.Add(ops[i + 1]);
                    ops.RemoveAt(i-1);
                    ops.RemoveAt(i);
                    i--;
                }
            }

        }
    }
   

    public override float Calculate()
    {
        float result = 0;
        for (int i = 0; i < Children.Count; i++)
        {
            result += Children[i].Calculate();
        }
        return result;
    }
}





