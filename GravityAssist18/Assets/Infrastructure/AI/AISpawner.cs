//using System.Collections.Generic;

//using UnityEngine;
//using Utility;
//using UnityEngine.Events;
//namespace Infrastructure
//{
//    public class AISpawner : MonoBehaviour
//    {
//        public List<Stockpile> stockPiles;
//        public AIUnit aiPrefab;
//        public AIManager AIManager;
//        AIUnit curAIUnit;
//        Camera cam;
 
//        public GameobjectPool pool;
//        private void Awake()
//        {
//            cam = Camera.main;
//        }

//        private void OnEnable()
//        {
//            curAIUnit = pool.GetFromPool().GetComponent<AIUnit>();
//            curAIUnit.transform.SetParent(transform, true);
//        }
//        public void Update()
//        {
//            var pos = MousePositioning.MouseToWorldPos(cam);
//            curAIUnit.transform.position = pos;
//            if (Input.GetMouseButtonDown(0))
//            {
//                AIManager.AIUnits.Add(curAIUnit);
//                NavMeshManager.UpdateNavMesh();
//                OnEnable();
//            }
//            if (Input.GetMouseButtonDown(1))
//            {
//                Destroy(curAIUnit.gameObject);
//                enabled = false;
//            }
//        }


//    }
//}


