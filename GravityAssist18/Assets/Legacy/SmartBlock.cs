//using UnityEngine;
//namespace Infrastructure
//{

//    public class SmartBlock : MonoBehaviour
//    {
//        public Vector2 removePos;
//        public Vector2 removeSize;

//        public bool removeCube;
//        public void Update()
//        {
//            if (Input.GetKeyDown(KeyCode.Period))
//            {
//                RemoveCube(removePos,removeSize);
//            }
//        }

//        public GameObject cubePF;

//        public void RemoveCube(Vector2 rpos,Vector2 rsize )
//        {
//            Vector2 p0 = new Vector2(transform.position.x, transform.position.y);
//            float xs1 = (p0.x - transform.localScale.x / 2);
//            float xs2 = (p0.x + transform.localScale.x / 2);
//            float xr1 = (rpos.x - rsize.x) / 2;
//            float xr2 = (rpos.x + rsize.x) / 2;

//            float ys1 = (p0.y - transform.localScale.y / 2);
//            float ys2 = (p0.y + transform.localScale.y / 2);
//            float yr1 = (rpos.y - rsize.y) / 2;
//            float yr2 = (rpos.y + rsize.y) / 2;

//            var s1 = new Vector2(xs2 - xs1, ys1 - yr1);
//            var p1 = new Vector2(xs1 + s1.x/2, yr1 + s1.y/2);

//            var s2 = new Vector2(xr1 - xs1,  yr1 - yr2 );
//            var p2 = new Vector2(xs1 + s1.x / 2, yr1 + s1.y / 2);

//            var s3 = new Vector2(xs2 - xs1, ys1 - yr1);
//            var p3 = new Vector2(xs1 + s1.x / 2, yr1 + s1.y / 2);

//            var s4 = new Vector2(xs2 - xs1, ys1 - yr1);
//            var p4 = new Vector2(xs1 + s1.x / 2, yr1 + s1.y / 2);
            

//            if (s1>0)
//            {
//                var leftGo = GameObject.Instantiate(cubePF);
//                leftGo.transform.position = new Vector3(p1, 0, 0);
//                leftGo.transform.localScale = new Vector3(s1, 1, 1);

//            }
//            if (s2 > 0)
//            {
//                var rightGo = GameObject.Instantiate(cubePF);
//                rightGo.transform.position = new Vector3(p2, 0, 0);
//                rightGo.transform.localScale = new Vector3(s2, 1, 1);
//            }
      

//            Destroy(gameObject);

//        }
//    }

//}
