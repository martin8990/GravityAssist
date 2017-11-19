using System.Collections.Generic;
public static class Calculator
{

    public static float Calculate(List<string> OperationTokens)
    {
        int numPrios = 2;
        List<Operation> operations = new List<Operation>();
        int PrioBoost = 0;
        int MaxPrio = 2;
        SetPriorities(OperationTokens, numPrios, operations, ref PrioBoost, ref MaxPrio);
        if (operations.Count > 0)
        {
            var result = operations[0].Calculate(operations[0]) as FLOAT32;
            if (result!=null)
            {
                return result.value;
            }
            else
            {
                return 0;
            }
        }
        else return 0;


    }

    private static void SetPriorities(List<string> OperationTokens, int numPrios, List<Operation> operations, ref int PrioBoost, ref int MaxPrio)
    {
        for (int i = 0; i < OperationTokens.Count; i++)
        {
            if (OperationTokens[i] == "(")
            {
                PrioBoost += numPrios;
                if (PrioBoost + numPrios > MaxPrio)
                {
                    MaxPrio = PrioBoost + numPrios;
                }
            }
            else if (OperationTokens[i] == ")")
            {
                PrioBoost -= numPrios;
            }

            var op = Numerics.Find(OperationTokens[i], PrioBoost);
            if (op != null)
            {
                operations.Add(op);
            }
        }
        for (int i = MaxPrio; i >= 1; i--)
        {
            Operators.ClaimChildren(operations, i);
        }
    }
}





