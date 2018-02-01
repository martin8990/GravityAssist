//using Utility;
//using UnityEngine;
//using Domain;
//namespace Infrastructure
//{

//    public class SplineMarkerControl : MonoBehaviour
//    {

//        [HideInInspector]
//        public bool addingPoints = false;
//        public SplineMarkerCreate markerCreate;
//        public SplineMarkerMove move;
//        public Camera cam;

//        public void StartAddingPoints()
//        {
//            addingPoints = true;
//        }

//        public void Update()
//        {
//            var mp = MousePositioning.MouseToWorldPos(cam);
//            if (addingPoints)
//            {
//                addingPoints = markerCreate.AddPoints(mp);
//            }
//            else
//            {
//                move.HoverOrMove(mp);
//            }
//        }

//    }



//}
