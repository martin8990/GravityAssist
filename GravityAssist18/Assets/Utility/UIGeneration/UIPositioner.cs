using System.Collections.Generic;
using UnityEngine;
public static class UIPositioner {

    public static void PositionVertically(Transform parent,RectTransform[] uiElements)
    {
        float divider = 1f / (uiElements.Length);
        for (int i = 0; i < uiElements.Length; i++)
        {
            uiElements[i].transform.SetParent(parent,false);
            uiElements[i].anchorMin = new Vector2(0, divider*i);
            uiElements[i].anchorMax = new Vector2(1, divider * (i+1f));
        }
    }
    public static void PositionHorizontally(Transform parent, RectTransform[] uiElements)
    {
        float divider = 1f / (uiElements.Length);
        for (int i = 0; i < uiElements.Length; i++)
        {
            uiElements[i].transform.SetParent(parent, false);
            uiElements[i].anchorMin = new Vector2( divider * i,0);
            uiElements[i].anchorMax = new Vector2( divider * (i + 1f),1);
        }
    }

    public static void Resize(float delta, RectTransform transform)
    {
        transform.localScale = (1f + delta) * transform.localScale;
    }
}
