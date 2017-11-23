using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Operators
{
    public static token Find(string Token,int prioBoost)
    {
        if (Token == "+")
        {
            var operation = new AddOperator(prioBoost);
            return operation;
        }
        
        else
        {
            return null;
        }
    }
    public static void ClaimChildren(List<token> ops, int prio)
    {
        if (ops.Count > 2)
        {
            for (int i = 1; i < ops.Count - 1; i++)
            {
                if (ops[i].kids.Count>0)
                {
                    ClaimChildren(ops[i].kids, prio);
                }
                if (ops[i].prio == prio)
                {
                    
                    ops[i].kids.Add(ops[i - 1]);
                    ops[i].kids.Add(ops[i + 1]);
                    ops[i].type = ops[i].kids[0].type;
                    if (ops[i].kids[0].type < ops[i].kids[1].type)
                    {
                        ops[i].type = ops[i].kids[1].type;
                    }
                    ops.RemoveAt(i - 1);
                    ops.RemoveAt(i);
                    i--;
                    
                }               
            }
        }
    }
}


public static class Functions
{
    public static token Find(string Token, int prioBoost)
    {

    }
}




