//using UnityEngine;

//namespace Infrastructure
//{

//    public class WallGrid : MonoBehaviour
//    {
//        public GameObject InterWall;
//        public GameObject WallEnd;
//        public GameObject WallCornerLeft;
//        public GameObject WallT;

//        public GameObject[,] wallMap;
//        int xOffset;
//        int zOffset;
//        float hOffset;
        
//        void OnEnable()
//        {
//            var s = transform.localScale;
//            var p = transform.position;
//            xOffset = (int)(p.x - s.x / 2f);
//            zOffset = (int)(p.z - s.z / 2f);
//            hOffset = (int)s.y;
//            int xScale = (int)transform.localScale.x;
//            int zScale = (int)transform.localScale.z;

//            wallMap = new GameObject[xScale, zScale];
//        }

//        public void PlaceWall(Vector3 worldPos, float Height)
//        {
//            int posX = (int)worldPos.x - xOffset;
//            int posZ = (int)worldPos.z - zOffset;

//            bool south = false;
//            bool east = false;
//            bool north = false;
//            bool west = false;

          
//        }


//    }




//}
