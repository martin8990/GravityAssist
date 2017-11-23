using UnityEngine;

public static class OperationCalculator
{
    public static void Calc(token op)
    {
        switch (op.type)
        {
            case dType.INT32:
                Debug.Log("Int : " + op.CalcInt());
                  
                break;
            case dType.FLOAT32:
                Debug.Log("Float : " + op.CalcFloat());
                break;
            case dType.INT32ARR:
                break;
            case dType.FLOAT32ARR:
                break;
            default:
                break;
        }
    }
}







