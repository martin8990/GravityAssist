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
    }
}
