//using UnityEngine;
//using Utility;

//namespace Infrastructure
//{
//    public class FloorBlock : BuildingBlock
//    {
        

//        public LayerMask foundationOrWallLayer;
//        public int floorLayer;

//        public float thickness = 1f;
       
        

//        public bool IsFoundationOnPosition(Vector3 pos)
//        {
//            Debug.DrawRay(pos + Vector3Int.up, Vector3Int.down*5);
//            if (Physics.Raycast(pos + Vector3Int.up, Vector3Int.down, 5f, foundationOrWallLayer))
//            {
//                return true;
//            }
//            return false;
//        }

//        public override void Transfrom(Vector3 p1, Vector3 p2)
//        {
//            if (Input.GetKeyDown(KeyCode.LeftShift))
//            {
//                thickness++;
//            }
//            if (Input.GetKeyDown(KeyCode.LeftControl))
//            {
//                thickness--;
//            }

//            var minHeight = Mathf.CeilToInt(p1.y);
//            var maxHeight = minHeight + thickness;

//            var minPos = (new Vector3(Mathf.Min(p1.x, p2.x),minHeight, Mathf.Min(p1.z, p2.z))).ToInt();
//            var maxPos = (new Vector3(Mathf.Max(p1.x, p2.x) + 1,maxHeight, Mathf.Max(p1.z, p2.z) + 1)).ToInt();
                        
//            var p3 = minPos + new Vector3Int(0, 0, maxPos.z - minPos.z);
//            var p4 = minPos + new Vector3Int(maxPos.x - minPos.x, 0, 0);
            
//            // Checking all corners
//            var corners = new Vector3[] { minPos + new Vector3(0.2f,0,0.2f),
//                maxPos - new Vector3(0.2f, 0, 0.2f),
//                p3 + new Vector3(0.2f, 0, -0.2f),
//                p4 + new Vector3(-0.2f, 0, 0.2f) };

//            valid = true;

//            for (int i = 0; i < corners.Length; i++)
//            {
//                if (!IsFoundationOnPosition(corners[i]))
//                {
//                    valid = false;
//                }
//            }

//            transform.position = new Vector3(minPos.x + maxPos.x, minPos.y + maxPos.y, minPos.z + maxPos.z) / 2f;
//            transform.localScale = maxPos - minPos;

//        }

//        public override void Complete()
//        {
//            gameObject.layer = floorLayer;
//        }


//    }
//}
