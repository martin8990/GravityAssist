using System.Collections.Generic;
using UnityEngine;
public class UIPositioner<myType> : Machine<myType,myType> where myType : MonoBehaviour, IUIPosition
{
    public override List<myType> Operate(List<myType> input)
    {
        int count = input.Count;
        float ds = 1f / (count + 1);
        for (int i = 0; i < count; i++)
        {

            float minX = i * ds;
            float maxX = i + 1 * ds;
            float minY = 0;
            float maxY = 1;
            input[i].rt.anchorMin = new Vector2(minX, minY);
            input[i].rt.anchorMax = new Vector2(maxX, maxY);
        }
        return input;
    }
}


