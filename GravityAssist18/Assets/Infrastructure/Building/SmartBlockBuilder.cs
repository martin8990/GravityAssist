using UnityEngine;
using UnityEngine.Events;
using System;
namespace Infrastructure
{
    public class SmartBlockBuilder : MonoBehaviour
    {
        [HideInInspector]
        public Action<CarvableBlock> OnNewSmartblock;
        public CarvableBlock smartBlockPrefab;
//        public Authority authority;
        
        public void BuildSmartBlock()
        {
            var smartBlock = Instantiate(smartBlockPrefab, transform);
            smartBlock.subDivider.SmartBlockPF = smartBlockPrefab;
            smartBlock.carveMaster.enabled = true; //.authority = authority;
            smartBlock.GetComponent<Collider>().enabled = true;
            OnNewSmartblock.Invoke(smartBlock);

        }


    }

}
