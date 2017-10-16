using System.Collections.Generic;
using UnityEngine;
public class DataBase<myType> : Slave<myType>
{
    public bool debug;
    public List<myType> myData;

    public override void Recieve(List<myType> input)
    {
        if (debug && myData.Count > 0)
        {
            Debug.Log(name + " Recieved new list of type " + myData[0].GetType().ToString() + " of size " + myData.Count);
        }
        else if (myData.Count == 0)
        {
            Debug.Log(name + " Recieved empty data");
        }
    }
}




