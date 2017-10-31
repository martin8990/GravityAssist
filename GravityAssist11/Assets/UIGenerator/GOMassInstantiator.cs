using System.Collections.Generic;
using UnityEngine;
public static class GOMassInstantiator
{
    public static List<GameObject> MassInstantiate(GameObject prefab, Transform parent, int amount)
    {
        var GOS = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            var GO = GameObject.Instantiate(prefab);
            GO.transform.SetParent(parent, false);
            GOS.Add(GO);
        }
        return GOS;
    }
}

