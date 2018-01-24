using UnityEngine;
using Utility;
using UnityEngine.Events;

namespace Infrastructure
{

    public class BuildController : MonoBehaviour
    {

        public LayerMask CTORMasks;
        Camera cam;
        public ConstructionEditor constructinEditor;
        public UnityEvent toConstructionEditor;
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

                if (MousePositioning.VerticalRayCast(pos, 5f, out hit, CTORMasks))
                {
                    constructinEditor.SelectedConstruction = hit.collider.gameObject.GetComponent<ConstructionPlan>();
                    toConstructionEditor.Invoke();
                }

            }
        }




    }
}
