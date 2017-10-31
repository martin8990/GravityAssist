using UnityEngine;
public static class GOMouseFollow
{
    public static void FollowMouse(GameObject go)
    {
        go.transform.position = Input.mousePosition;
    }

}