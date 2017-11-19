using System;
using System.Collections.Generic;
public class Operation
{
    public Operation arg1;
    public Operation arg2;


    public Func<Operation, dType> Calculate;
    public Operation parent;
    public int prio;
    
    public Operation(int prio, Func<Operation, dType> calculate)
    {
        this.prio = prio;
        Calculate = calculate;
    }
}

public class dType
{
    public _dType type;
        
}
public class FLOAT32 : dType
{
    public float value;

    public FLOAT32(float value)
    {
        type = _dType.FLOAT32;
        this.value = value;
    }
}
public class FLOAT64 : dType
{
    public new _dType type = _dType.FLOAT64;
    public double value;
}

public enum _dType {INT32,FLOAT32,FLOAT64,COMPLEX64,COMPLEX128,BOOL}






