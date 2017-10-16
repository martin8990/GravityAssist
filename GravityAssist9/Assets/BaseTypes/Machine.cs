using System.Collections.Generic;
using UnityEngine;
public abstract class Machine<Input,Output> : Slave<Input>,IMaster<Output>
{
    [SerializeField]
    List<Slave<Output>> slaves;


    public List<Slave<Output>> Slaves { get { return slaves; } set { slaves = value; } }
    
    public abstract List<Output> Operate(List<Input> input);
    public override void Recieve(List<Input> input)
    {
        var myOutput  = Operate(input);
        if (myOutput != null)
        {
            Send(myOutput);
        }
        else
        {
            Debug.Log("output is null");
        }

    }
    public void Send(List<Output> output)
    {
        foreach (var slave in slaves)
        {
            slave.Recieve(output);
        }
    }
}



