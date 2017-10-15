using UnityEngine;
public class DataBase<myType> : Machine<myType>
{
    public bool debug;
    public override void Operate()
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

    public override void TriggerNextSlaves()
    {
        // I dont automatically trigger other slaves
    }

}




