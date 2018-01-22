using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class ControlMaster : MonoBehaviour
    {
        bool inSubControl = false;
        Camera cam;
        private void Start()
        {
            cam = Camera.main;
        }

        public void Update()
        {
            if (!inSubControl)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var pos = MousePositioning.MouseToWorldPos(cam);
                    RaycastHit hit = new RaycastHit();
                    MousePositioning.VerticalRayCast(pos, 5f, out hit);
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
        public void ToggleInSubControl()
        {
            inSubControl = !inSubControl;
        }
    }
}
