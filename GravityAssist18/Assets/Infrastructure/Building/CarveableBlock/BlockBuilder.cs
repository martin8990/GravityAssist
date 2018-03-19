using UnityEngine;
using UnityEngine.Events;
using System;
namespace Infrastructure
{
    public class BlockBuilder : MonoBehaviour
    {
        [HideInInspector]
        public Action<CarvableBlock> OnNewblock;
        public CarvableBlock BlockPrefab;

        
        public void BuildSmartBlock()
        {
            var smartBlock = Instantiate(BlockPrefab, transform);
            smartBlock.subDivider.SmartBlockPF = BlockPrefab;
            smartBlock.GetComponent<Collider>().enabled = true;
            OnNewblock.Invoke(smartBlock);

        }


    }

}
