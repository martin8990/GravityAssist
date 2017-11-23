using System.Collections.Generic;
public static class OperationPlanner
{

    public static token Plan(List<string> OperationTokens)
    {
        int numPrios = 2;
        List<token> operations = new List<token>();
        int PrioBoost = 0;
        int MaxPrio = 2;
        SetPriorities(OperationTokens, numPrios, operations, ref PrioBoost, ref MaxPrio);

        if (operations.Count>0)
        {
            return operations[0];
        }

        return null;


    }

    private static void SetPriorities(List<string> OperationTokens, int numPrios, List<token> operations, ref int PrioBoost, ref int MaxPrio)
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

            var op = NumericsFinder.Find(OperationTokens[i], PrioBoost);
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





