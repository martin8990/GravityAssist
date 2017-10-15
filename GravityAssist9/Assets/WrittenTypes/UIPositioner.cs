using System.Collections.Generic;
using UnityEngine;
public class UIPositioner<Input> : Machine<Input> where Input : MonoBehaviour, IUIPosition
{
    public List<Input> output;
    public Machine<Input> nextSlave;

    public override void Operate()
    {
        int count = myData.Count;
        float ds = 1f / (count+1);
        for (int i = 0; i < count; i++)
        {

            float minX = i * ds;
            float maxX = i + 1 * ds;
            float minY = 0;
            float maxY = 1;
            myData[i].rt.anchorMin = new Vector2(minX, minY);
            myData[i].rt.anchorMax = new Vector2(maxX, maxY);
        }
        output = myData;
    }

    public override void TriggerNextSlaves()
    {
        nextSlave.Trigger(output);
    }
}


