using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure
{
    public class ConstructionEditor : MonoBehaviour
    {
        [HideInInspector]
        public GameObject SelectedConstruction;
        public BuildColors ConstructionColors;

        public UnityEvent ToBuildController;
        
        private void OnEnable()
        {
            ConstructionColors.SetSelect(SelectedConstruction.gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Destroy(SelectedConstruction.gameObject);
                ToBuildController.Invoke();
                ConstructionColors.SetPlan(SelectedConstruction.gameObject);
            }
            if (Input.GetMouseButtonDown(1))
            {
                ToBuildController.Invoke();
                ConstructionColors.SetPlan(SelectedConstruction.gameObject);
            }
        }
    }
}
