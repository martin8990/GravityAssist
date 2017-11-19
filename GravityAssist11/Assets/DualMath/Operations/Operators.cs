using System.Collections.Generic;
using UnityEngine;

public static class Operators
{
    public static Operation Find(string Token,int prioBoost)
    {
        if (Token == "+")
        {
            var operation = new Operation(1+prioBoost, Add);
            return operation;
        }
        
        else
        {
            return null;
        }
    }
    public static void ClaimChildren(List<Operation> ops, int prio)
    {
        if (ops.Count > 2)
        {
           
            for (int i = 1; i < ops.Count - 1; i++)
            {
                if (ops[i].arg1!=null)
                {
                    ClaimChildren(new List<Operation> { ops[i].arg1, ops[i].arg2 }, prio);
                }
                if (ops[i].prio == prio)
                {
                    ops[i].arg1 = ops[i - 1];
                    ops[i].arg2 = (ops[i + 1]);
                    ops.RemoveAt(i - 1);
                    ops.RemoveAt(i);
                    i--;
                }
               
            }
        }
    }
    
    public static dType Add(Operation op)
    {
        if (op.arg1!=null && op.arg2!=null)
        {
            var val1 = op.arg1.Calculate(op.arg1);
            var val2 = op.arg1.Calculate(op.arg2);
            if (val1 != null && val2 != null)
            {
                var t1 = val1.type;
                var t2 = val1.type;

                if (t1 == _dType.FLOAT32 && t1 == _dType.FLOAT32)
                {
                    var Float1 = val1 as FLOAT32;
                    var Float2 = val1 as FLOAT32;
                    if (Float1 != null && Float2 != null)
                    {
                        var f1 = Float1.value;
                        var f2 = Float2.value;
                        var res = f1 + f2;
                        return new FLOAT32(res);
                    }
                }
                return null;

            }

            return null;
        }
        return null;
       
    }

}







