using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure
{
    public class ConstructionEditor : MonoBehaviour
    {
        [HideInInspector]
        public ConstructionPlan SelectedConstruction;
        public ConstructionColors cubeColors;

        public UnityEvent ToBuildController;
        
        private void OnEnable()
        {
            cubeColors.SetSelect(SelectedConstruction.gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Destroy(SelectedConstruction.gameObject);
                ToBuildController.Invoke();
                cubeColors.SetPlan(SelectedConstruction.gameObject);
            }
            if (Input.GetMouseButtonDown(1))
            {
                ToBuildController.Invoke();
                cubeColors.SetPlan(SelectedConstruction.gameObject);
            }
        }
    }
}
