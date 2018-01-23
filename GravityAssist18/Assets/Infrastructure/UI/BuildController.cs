using UnityEngine;
using Utility;
using UnityEngine.Events;

namespace Infrastructure
{

    public class BuildController : MonoBehaviour
    {

        public LayerMask CubeMask;
        Camera cam;
        public CubeEditor cubeEditor;
        public UnityEvent toCubeEditor;
        private void Start()
        {
            cam = Camera.main;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos = MousePositioning.MouseToWorldPos(cam);
                RaycastHit hit = new RaycastHit();

                if (MousePositioning.VerticalRayCast(pos, 5f, out hit, CubeMask))
                {
                    cubeEditor.currentCubePlan = hit.collider.gameObject.GetComponent<CubePlan>();
                    toCubeEditor.Invoke();
                }

            }
        }




    }
}
