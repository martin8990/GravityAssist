//using UnityEngine;
//using Utility;
//using UnityEngine.Events;
//using UnityEngine.UI;
//using System.Collections.Generic;



//namespace Infrastructure
//{


//    public class BuildPlanner : MonoBehaviour
//    {

//        public LayerMask buildMask;
//        public Text costText;
//        public List<Block> blocks;
//        public int index;

//        Camera cam;
//        Block curBlock;
//        Vector3 p1;
//        Vector3 p2;

//        private void OnDrawGizmos()
//        {
//            Gizmos.color = Color.green;
//            Gizmos.DrawCube(p1, Vector3.one);

//            Gizmos.color = Color.red;
//            Gizmos.DrawCube(p2, Vector3.one);
//        }

//        bool Dragging;
        
//        void Start()
//        {
//            cam = Camera.main;
//        }
//        void OnEnable()
//        {
//            curBlock = GameObject.Instantiate(blocks[index], transform);
//        }

//        void Update()
//        {
//            var pos = Snap.GetSnappedPos(cam, Vector3.one, ~buildMask);

//            if (!Dragging)
//            {
//                p1 = pos;
//            }
//            if (Input.GetMouseButtonDown(0))
//            {
//                Dragging = true;                
//            }
            
//            if (Input.GetMouseButtonDown(1))
//            {
//                Destroy(curBlock.gameObject);
//                this.enabled = false;
//            }

//            p2 = pos;
//            curBlock.TransformBlock(p1, p2);
//            costText.text = curBlock.cost.ToString();

//            if (Input.GetMouseButtonUp(0))
//            {
//                Dragging = false;
//                if (curBlock.valid)
//                {
//                    curBlock.CompleteBlock();
//                    OnEnable();
//                }
//            }

//        }

//        public void SetBlock(int id)
//        {
            
//            index = id;
//            enabled = true;
//        }
//    }
//}
