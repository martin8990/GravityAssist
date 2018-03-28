//using System.Collections.Generic;
//using UnityEngine;
//using Utility;
//namespace Infrastructure
//{

//    public class UnitMover : MonoBehaviour
//    {
//        Camera cam;
//        private void Awake()
//        {
//            cam = Camera.main;
//        }
//        public void OnMove(List<FriendlyAIUnit> selected)
//        {
//            for (int i = 0; i < selected.Count; i++)
//            {
//                var order = selected[i].gameObject.AddComponent<MoveOrder>();
//                order.destination = MousePositioning.MouseToWorldPos(cam);
//                selected[i].orders.Enqueue(order);
//            }
//        }
//    }

//}


