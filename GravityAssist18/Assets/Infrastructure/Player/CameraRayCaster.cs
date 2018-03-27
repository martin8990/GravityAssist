using System;
using UnityEngine;
using System.Collections;
namespace Infrastructure
{

    public class CameraRayCaster : MonoBehaviour
    {
        public float range = 100f;
        public Camera cam;
        public LayerMask TargetLayer;

        public event Action<GameObject> OnHitGO = delegate { };
        public event Action<Vector3> OnHitPoint = delegate { };

        public void Raycast()
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, TargetLayer))
            {
                var go = hit.collider.gameObject;
                OnHitGO(go);
                OnHitPoint(hit.point);
            }
        }
        
        
    }




}


