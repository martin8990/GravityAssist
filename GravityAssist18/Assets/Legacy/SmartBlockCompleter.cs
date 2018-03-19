//using System;
//using UnityEngine;
//using UnityEngine.Events;

//namespace Infrastructure
//{
//    public class SmartBlockCompleter : MonoBehaviour
//    {

//        public int SmartBlockLayer;


//        [HideInInspector]
//        public Action<PastEvent> blockCompleted;

//        public void CompleteBlock(CarvableBlock curBlock)
//        {
//            curBlock.Commit();
//            curBlock.gameObject.layer = SmartBlockLayer;
//            curBlock.carveMaster.enabled = false;
//            var hElement = new AddedBlock(curBlock);
//            blockCompleted.Invoke(hElement);

//        }

//    }

//}
