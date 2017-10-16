using System.Collections.Generic;
using UnityEngine;
public class InputBehaviour<T> : MonoBehaviour,IMaster<T>
{
    public List<Slave<T>> slaves;
    public DataBase<T> dataBase;

    public List<Slave<T>> Slaves { get { return slaves; } set { slaves = value; } }

    public void Input()
    {
        List<T> output = new List<T>();
        if (dataBase!=null)
        {
            output = dataBase.myData;
        }
        Send(output);
    }

    public void Send(List<T> output)
    {
        foreach (var slave in slaves)
        {
            slave.Recieve(output);
        }
    }   

}




