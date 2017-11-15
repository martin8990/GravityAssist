using System.Collections.Generic;
using UnityEngine;
public static class UIPositioner {

    public static void PositionVertically(Transform parent, List<RectTransform> uiElements)
    {
        float divider = 1f / (uiElements.Count);
        for (int i = 0; i < uiElements.Count; i++)
        {
            uiElements[i].transform.SetParent(parent,false);
            uiElements[i].anchorMin = new Vector2(0, divider*i);
            uiElements[i].anchorMax = new Vector2(1, divider * (i+1f));
        }
    }
    public static void PositionHorizontally(Transform parent, List<RectTransform> uiElements)
    {
        float divider = 1f / (uiElements.Count );
        for (int i = 0; i < uiElements.Count; i++)
        {
            uiElements[i].transform.SetParent(parent, false);
            uiElements[i].anchorMin = new Vector2( divider * i,0);
            uiElements[i].anchorMax = new Vector2( divider * (i + 1f),0);
        }
    }

    public static void Resize(float delta, RectTransform transform)
    {
        transform.localScale = (1f + delta) * transform.localScale;
    }
}
