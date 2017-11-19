using System.Collections.Generic;
using UnityEngine;

public static class Operators
{
     public static Operation Find(string Token)
    {
        if (Token == "+")
        {
            var operation = new Operation(1,Add);
            return operation;
        }
        else if(Token == "-")
        {
            var operation = new Operation(1, Subtract);
            return operation;
        }
        else if(Token == "*")
        {
            var operation = new Operation(2, Mult);
            return operation;

        }
        else if (Token == "/")
        {
            var operation = new Operation(2, div);
            return operation;

        }
        else
        {
            return null;
        }
    }
    public static void ClaimChildren(List<Operation> ops, int prio)
    {
        for (int j = prio+1; j >= 1; j--)
        {
            if (ops.Count > 2)
            {
                for (int i = 1; i < ops.Count - 1; i++)
                {
                    
                        ops[i].Children.Add(ops[i - 1]);
                        ops[i].Children.Add(ops[i + 1]);
                        ops.RemoveAt(i - 1);
                        ops.RemoveAt(i);
                        i--;
                }
            }
        }
        
    }
    public static float Add(Operation op)
    {
        var kids = op.Children;
        float result = 0;
        for (int i = 0; i < kids.Count; i++)
        {
            result += kids[i].Calculate(kids[i]);
        }
        return result;
    }
    public static float Subtract(Operation operation)
    {
        var kids = operation.Children;
        float result = kids[0].Calculate(kids[0]);
        for (int i = 1; i < kids.Count; i++)
        {
           result -= kids[i].Calculate(kids[i]);
        }
        return result;
    }
    public static float Mult(Operation op)
    {
        var kids = op.Children;
        float result = kids[0].Calculate(kids[0]);
        for (int i = 1; i < kids.Count; i++)
        {
            result *= kids[i].Calculate(kids[i]);
        }
        return result;

    }
    public static float div(Operation op)
    {
        var kids = op.Children;
        float result = kids[0].Calculate(kids[0]);
        for (int i = 1; i < kids.Count; i++)
        {
            result = result / kids[i].Calculate(kids[i]);
        }
        return result;

    }
}







