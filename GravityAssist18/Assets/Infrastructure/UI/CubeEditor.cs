using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure
{
    public class CubeEditor : MonoBehaviour
    {
        public ConstructionPlan currentCubePlan;
        public UnityEvent ToBuildController;
        public CubeColors cubeColors;

        private void OnEnable()
        {
            cubeColors.SetSelect(currentCubePlan.gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Destroy(currentCubePlan.gameObject);
                ToBuildController.Invoke();
                cubeColors.SetPlan(currentCubePlan.gameObject);
            }
            if (Input.GetMouseButtonDown(1))
            {
                ToBuildController.Invoke();
                cubeColors.SetPlan(currentCubePlan.gameObject);
            }
        }
    }
}
