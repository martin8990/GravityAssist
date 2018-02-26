//using UnityEngine;
//using Utility;

//namespace Infrastructure
//{
//    public class Wall : MonoBehaviour
//    {
//        public GameObject SamePosWall = null;
//        public CInt WallLayer;

//        void OnTriggerEnter(Collider other)
//        {
//            int layer = other.gameObject.layer;
//            if (WallLayer == layer)
//            {
//                SamePosWall = other.gameObject ;
//            }
//        }
//        void OnTriggerExit(Collider other)
//        {
//            int layer = other.gameObject.layer;
//            if (WallLayer == layer)
//            {
//                SamePosWall = null;
//            }
//        }
//        public void RemoveWallOnPosition()
//        {
//            if (SamePosWall!=null)
//            {
//                SamePosWall.SetActive(false);
//            }
//        }    

//        public void RestoreRemovedWall()
//        {
//            SamePosWall.SetActive(true);
//        }

//    }
        
//}
