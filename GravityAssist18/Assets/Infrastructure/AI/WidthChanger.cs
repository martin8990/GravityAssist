using UnityEngine;
using Utility;
using UnityEngine.AI;
namespace Infrastructure
{
    public class WidthChanger : MonoBehaviour
    {
        [Button]
        public void ChangeWidth()
        {
            this.GetComponent<NavMeshLink>().width = this.GetComponent<NavMeshLink>().width += 0.011f;
        }
    }
}
