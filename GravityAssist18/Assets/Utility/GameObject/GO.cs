using UnityEngine;

namespace Utility
{
    public static class monoBehave
    {
        public static void DestroyKids(this MonoBehaviour go)
        {
            for (int i = go.transform.childCount - 1; i >= 0; i--)
            {
              MonoBehaviour.DestroyImmediate(go.transform.GetChild(i).gameObject);
            }
        }
        public static void DestroyKids(this GameObject go)
        {
            for (int i = go.transform.childCount - 1; i >= 0; i--)
            {
                MonoBehaviour.DestroyImmediate(go.transform.GetChild(i).gameObject);
            }
        }
        public static GameObject[] GetKids(this GameObject go)
        {
            var kids = new GameObject[go.transform.childCount];
            for (int i = go.transform.childCount - 1; i >= 0; i--)
            {
                kids[i] = go.transform.GetChild(i).gameObject;
            }
            return kids;
        }
    }

}
