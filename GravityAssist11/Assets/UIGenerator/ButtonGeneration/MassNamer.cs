using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class MassNamer
{
    public static void MassRename(List<GameObject> Objects, List<string> Names)
    {
        if (Names.Count!=Objects.Count)
        {
            Debug.Log("LenghtError");
        }
        else
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                var text = Objects[i].GetComponentInChildren<Text>().text;
                if (text!=null)
                {
                    text = Names[i];
                }
            }
        }

        

    }
}


