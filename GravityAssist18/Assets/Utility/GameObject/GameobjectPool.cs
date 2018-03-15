using UnityEngine;
using System.Collections.Generic;

namespace Utility
{
    public class GameobjectPool : MonoBehaviourExt
    {
        public GameObject prefab;
        public GameObject[] GoArr;
        Queue<GameObject> pool;
        public int poolCount;

        [Button]// run in editor
        public void FillPool()
        {
            GoArr = GoArr.Init(poolCount, () => Instantiate(prefab, transform));
            GoArr.Iter((x) => x.SetActive(false));
        }
        void Awake()
        {
            pool = new Queue<GameObject>(GoArr);    
        }
        public GameObject GetFromPool()
        {
            var go = pool.Dequeue();
            go.SetActive(true);
            return go;
        }
        public void ReturnToPool(GameObject go)
        {           
            go.SetActive(false);
            pool.Enqueue(go);
        }

    }

}
