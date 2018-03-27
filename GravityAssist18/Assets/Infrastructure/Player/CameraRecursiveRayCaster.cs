using System;
using UnityEngine;
namespace Infrastructure
{
    public class CameraRecursiveRayCaster : MonoBehaviour
    {
        public float range = 100f;
        public Camera cam;
        public LayerMask TargetLayer;
        public int maxRecursion = 8;
        int curRecursion = 0;
        public event Action<GameObject> OnHitGO = delegate { };
        public event Action<Vector3> OnHitPoint = delegate { };

        public void RaycastRecursively()
        {
            curRecursion = 0;
            var origin = cam.transform.position;
            float _range = range;
            RecursiveRayCast(cam.transform.position, range);
        }
        void RecursiveRayCast(Vector3 origin, float _range)
        {

            RaycastHit hit;
            if (Physics.Raycast(origin, cam.transform.forward, out hit, _range, TargetLayer))
            {
                var go = hit.collider.gameObject;
                OnHitGO(go);
                OnHitPoint(hit.point);
                if (curRecursion < maxRecursion)
                {
                    var nextRange = _range - Vector3.Distance(hit.point, origin);
                    curRecursion++;
                    if (nextRange > 0)
                    {
                        RecursiveRayCast(hit.point, _range - nextRange);
                    }
                }

            }
        }
    }




}


