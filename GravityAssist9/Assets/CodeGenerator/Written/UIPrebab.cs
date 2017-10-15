using UnityEngine;
[System.Serializable]
public class UIPrebab : IPrefab, IUIPosition
{
    public Transform Parent
    {
        get
        {
            return parent;
        }

        set
        {
            parent = value;
        }
    }
    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

    [SerializeField]
    Transform parent;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    RectTransform rect;
    public RectTransform rt
    {
        get
        {
            return rect;
        }

        set
        {
            rect = value;
        }
    }
    
}
