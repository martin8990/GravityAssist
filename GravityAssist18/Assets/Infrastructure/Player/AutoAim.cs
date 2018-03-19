using UnityEngine;

namespace Infrastructure
{
    public class AutoAim : MonoBehaviour
    {
        public Transform target;
        public void Update()
        {
            transform.LookAt(target.position);
        }
    }




}


