using UnityEngine;

namespace Infrastructure
{
    public abstract class BuildingBlock : MonoBehaviour
    {
        
        protected Material mat;
        protected bool valid;
        public BuildMaterial buildMaterial;
        public CColor invalidColor;
        private void Awake()
        {
            mat = GetComponent<MeshRenderer>().material;
            mat.color = buildMaterial.color;
        }

        public abstract void Transfrom(Vector3 p1, Vector3 p2);
        public abstract void Complete();
        public float CalculateCost()
        {
            var s = transform.localScale;
            return s.x * s.y * s.z * buildMaterial.costPerBlock;
        }
        public bool IsValidPosition()
        {
            if (valid)
            { 
                mat.color = buildMaterial.color; 
            }
            else
            {
                mat.color = invalidColor.color;
            }
            return valid;
        }
    }
}
