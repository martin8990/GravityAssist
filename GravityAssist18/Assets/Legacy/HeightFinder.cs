//using UnityEngine;


//namespace Infrastructure
//{

//    public class HeightFinder : MonoBehaviour
//    {

//        public GameObject HeightMeasurer;
//        public float heigthmargin = 1f;
//        public int physicsSteps = 100;
//        private void Awake()
//        {
//            HeightMeasurer = GameObject.Instantiate(HeightMeasurer, transform);
//        }
//        public float FindHeight(Vector3 p1, Vector3 p2)
//        {
//            float startingHeight = Mathf.Max(p1.y, p2.y) + 1;

//            HeightMeasurer.transform.localScale = new Vector3(Mathf.Abs(p2.x - p1.x) + 1f, 1, Mathf.Abs(p2.z - p1.z) + 1f);
//            HeightMeasurer.transform.position = new Vector3(0.5f * (p1.x + p2.x), startingHeight, 0.5f * (p1.z + p2.z));
//            Physics.Simulate(physicsSteps);
//            return HeightMeasurer.transform.position.y - 0.5f;
//        }

//    }
//}
