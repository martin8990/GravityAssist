//using System.Collections.Generic;
//using UnityEngine;
//using Utility;

//namespace Infrastructure
//{
//    [RequireComponent(typeof(UnitMover))]
//    [RequireComponent(typeof(UnitSelector))]

//    public class MainActionUI : MonoBehaviour
//    {
//        public List<FriendlyAIUnit> selected = new List<FriendlyAIUnit>();
//        UnitMover unitMover;
//        UnitSelector unitSelector;
//        void Awake()
//        {
//            unitMover = GetComponent<UnitMover>();
//            unitSelector = GetComponent<UnitSelector>();
//        }
//        public void OnUpdate()
//        {
//            if (Input.GetMouseButtonDown(0))
//            {
//                unitSelector.OnFirstClick();    
//            }
//            if (Input.GetMouseButtonUp(0))
//            {
//                selected = unitSelector.OnUp();
//            }
//            if (Input.GetMouseButtonDown(1))
//            {
//                unitMover.OnMove(selected);
//            }
//        }
//    }

//}


