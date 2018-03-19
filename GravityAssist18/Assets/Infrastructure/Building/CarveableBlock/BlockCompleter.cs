using System;
using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure
{
    public class BlockCompleter : MonoBehaviour
    {

        public int SmartBlockLayer;


        [HideInInspector]
        public Action<PastEvent> blockCompleted;

        public void CompleteBlock(CarvableBlock curBlock)
        {
//            curBlock.Commit();
            curBlock.gameObject.layer = SmartBlockLayer;
            var hElement = new AddedBlock(curBlock);
            blockCompleted.Invoke(hElement);
        }

    }

}
