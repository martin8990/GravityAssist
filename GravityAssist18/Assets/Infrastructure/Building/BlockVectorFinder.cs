using UnityEngine;

namespace Infrastructure
{
    public class BlockVectorModifier : MonoBehaviour
    {
        public int height;
        public bool forceStraight;
        public bool fill;
        public HeightMap heightMap;
        public SmartBlockManager smartBlock;
        public float Cost;

        public void ModifyMouseVectors(Vector3Int p1, Vector3Int p2)
        {

            if (forceStraight)
            {
                float dx = Mathf.Abs(p2.x - p1.x);
                float dz = Mathf.Abs(p2.z - p1.z);
                if (dx > dz)
                {
                    p2 = new Vector3Int(p2.x, height, p1.z);
                }
                else
                {
                    p2 = new Vector3Int(p1.x, height, p2.z);
                }
            }
            else
            {
                p2 = new Vector3Int(p2.x, height, p2.z);
            }
            if (fill)
            {
                
            }
        }



    }

        

}
