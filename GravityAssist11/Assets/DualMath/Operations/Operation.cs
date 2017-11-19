using System;
using System.Collections.Generic;
public class Operation
{
    public List<Operation> Children = new List<Operation>();
    public Operation parent;
    public int prio;
    public Func<Operation, float> Calculate;

    public Operation(int prio, Func<Operation, float> calculate)
    {
        this.prio = prio;
        Calculate = calculate;
    }
}





