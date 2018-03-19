using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class FoundationBuilder : MonoBehaviour
    {
        public int height;
        public HeightMap heightMap;
                   
        public void TransfromBlock(Vector3 p1, Vector3 p2, CarvableBlock block)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                height++;
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                height--;
            }
            var minPos = (new Vector3(Mathf.Min(p1.x, p2.x), Mathf.Ceil(Mathf.Min(p1.y, p2.y)), Mathf.Min(p1.z, p2.z))).ToInt();
            var maxPos = (new Vector3(Mathf.Max(p1.x, p2.x), Mathf.Max(p1.y, p2.y), Mathf.Max(p1.z, p2.z)) + Vector3.one).ToInt();
            maxPos = new Vector3Int(maxPos.x, minPos.y + height, maxPos.z);

            float minHeight = 100;
            for (int x = minPos.x; x < maxPos.x; x++)
            {
                for (int y = minPos.z; y < maxPos.z; y++)
                {

                    minHeight = Mathf.Min(heightMap.heightMap[x, y], minHeight);
                }
            }

            if (minHeight > height || block.collisionTriggerer.TriggeredObjects.Count > 0)
            {
                Debug.Log("yo");
               block.valid = false;
                block.materializer.SetInvalidColor();
            }
            else
            {
                block.valid = true;
                block.materializer.SetDefaultColor();
            }       
          
            minPos = new Vector3Int(minPos.x, (int)minHeight, minPos.z);
            maxPos = new Vector3Int(maxPos.x, height, maxPos.z);

            block.transform.position = new Vector3(minPos.x + maxPos.x, minPos.y + maxPos.y, minPos.z + maxPos.z) / 2f;
            block.transform.localScale = maxPos - minPos;
        }
    }
}
