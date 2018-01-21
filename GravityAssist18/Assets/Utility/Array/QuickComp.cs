using UnityEngine;
namespace Utility
{
    public static class QuickComp
    {
        public static Material Mat(GameObject go)
        {
           return go.GetComponent<MeshRenderer>().material;
        }
    }
}
