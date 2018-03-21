using UnityEngine;
namespace Infrastructure
{
    public class Materializer : MonoBehaviour
    {
        Material Mat
        {
            get
            {
                if (mat == null)
                {
                    mat = GetComponent<MeshRenderer>().material;
                }
                return mat;
            }
        }
        Material mat;
    
        //[HideInInspector]
        public BuildMaterial buildMaterial;
        public CColor invalidColor;
        public void SetDefaultColor()
        {
            Mat.color = buildMaterial.color;
        }
        public void SetInvalidColor()
        {
            Mat.color = invalidColor.color;
        }
        public float GetCost()
        {
            var p = transform.localScale;
            return p.x * p.y * p.z * buildMaterial.costPerBlock;
        }
        public float GetWork()
        {
            var p = transform.localScale;
            return p.x * p.y * p.z * buildMaterial.workPerBlock;
        }

    }

}
