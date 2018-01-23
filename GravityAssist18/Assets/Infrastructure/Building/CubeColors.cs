using UnityEngine;

namespace Infrastructure
{
    [CreateAssetMenu()]
    public class CubeColors : ScriptableObject
    {
        public Color PlanColor;
        public Color SelectedColor;
        public Color BuildColor;
        public Color InvalidColor;

        public void SetPlan(GameObject cube)
        {
            cube.GetComponent<MeshRenderer>().material.color = PlanColor;
        }
        public void SetSelect(GameObject cube)
        {
            cube.GetComponent<MeshRenderer>().material.color = SelectedColor;
        }
        public void SetBuild(GameObject cube)
        {
            cube.GetComponent<MeshRenderer>().material.color = BuildColor;
        }
        public void SetInvalid(GameObject cube)
        {
            cube.GetComponent<MeshRenderer>().material.color = InvalidColor;
        }


    }
}
