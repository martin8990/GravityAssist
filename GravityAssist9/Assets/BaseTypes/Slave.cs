using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine<Input,Output> : Slave<Input>,Master<Output>
{
    [SerializeField]
    Slave<Output> slave;


    public List<Output> myOutput;
    public Slave<Output> Slave { get { return slave; } set {slave = value } }
    
    public abstract void Operate(List<Input> input);
    public override void Listen(List<Input> input)
    {
        Operate(input);
        if (myOutput != null)
        {
            Speak(myOutput);
        }
        else
        {
            Debug.Log("output is null");
        }

    }
    public void Speak(List<Output> output)
    {
        slave.Listen(output);
    }


}


public interface Master<T>
{
    void Speak(List<T> output);
    Slave<T> Slave { get; set; }
}
public abstract class Slave<Input> : ScriptableObject
{
    public abstract void Listen(List<Input> input);
}



