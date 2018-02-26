using UnityEngine;
using Utility;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Infrastructure
{

    public class SmartBlockManager : MonoBehaviour
    {
        public SmartBlock smartBlockPrefab;
        int priority = int.MaxValue;
        public void AddBlock()
        {
            var go = Instantiate(smartBlockPrefab, transform);
            go.Priority = priority;
            priority--;
        }
        public void TransformBlock(Vector3Int min, Vector3Int max,SmartBlock block)
        {

            block.OnEdit();
            block.transform.position= new Vector3(min.x + max.x, min.y + max.y, min.z + max.z) / 2f;
            block.transform.localScale = max - min;

        }

    }

    

}
