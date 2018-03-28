
//using UnityEngine;
//using Utility;

//namespace Infrastructure
//{
//    public class TurretSpawner : MonoBehaviour
//    {
//        public Turret turretPrefab;
//        public Camera cam;
//        Turret turret;
//        public LayerMask FriendlyMask = 18;
//        float Height = 0;
//        public int price = 50;

//        public void OnEnable()
//        {
//            if (PlayerBudget.budget >= price)
//            {
//                PlayerBudget.RemoveMoney(price);
//                turret = Instantiate(turretPrefab);
//            }


//        }
//        public void Commit()
//        {
//            AIManager.AddAI(turret);
//            enabled = false;
//        }
//        public void Update()
//        {
//            var pos  = MousePositioning.MouseToWorldPos(cam,~FriendlyMask);
//            turret.transform.position = pos + Vector3.up*Height;
//            if (Input.GetMouseButtonDown(0))
//            {
//                Commit();
//            }
//            if (Input.GetKeyDown(KeyCode.LeftShift))
//            {
//                Height++;
//            }
//            if (Input.GetKeyDown(KeyCode.LeftControl))
//            {
//                Height--;
//            }

//        }

//    }
//}


