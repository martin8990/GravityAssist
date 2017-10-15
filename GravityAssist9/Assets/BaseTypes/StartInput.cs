using System.Collections.Generic;
using UnityEngine;
public class StartInput<T> : MonoBehaviour
{
    public Machine<T> slave;
    public DataBase<T> dataBase;
    private void Start()
    {
        if (dataBase!=null)
        {
            slave.Trigger(dataBase.myData);

        }
        else
        {
            slave.Trigger(new List<T>());     
        }
    }
}




