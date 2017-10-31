using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class UIGenerator
{
    public static List<GameObject> GenerateUI(GameObject prefab, Transform parent, int amount,UILayout layout)
    {
        var GOS = GOMassInstantiator.MassInstantiate(prefab, parent, amount);
        var rectTFs = ComponentsGetter<RectTransform>.GetFromGOS(GOS);
        Debug.Log(GOS.Count);
        if (layout == UILayout.Vertical)
        {
            UIPositioner.PositionVertically(parent, rectTFs);
        }
        else if (layout == UILayout.Horizontal)
        {
            UIPositioner.PositionHorizontally(parent, rectTFs);
        }
        return GOS;
    }
}

public static class ComponentsGetter<T>
{
    public static List<T> GetFromGOS(List<GameObject> GOS)
    {
        return GOS.Select(t => t.GetComponent<T>()).ToList();
    }
}
