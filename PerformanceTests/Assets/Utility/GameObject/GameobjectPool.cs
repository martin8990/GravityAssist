using UnityEngine;
using System.Collections.Generic;

namespace Utility
{
    public class GameobjectPool : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject[] GoArr;
        Queue<GameObject> pool;
        public int poolCount;

        
        void Awake()
        {
            GoArr = GoArr.Init(poolCount, () => Instantiate(prefab, transform));
            GoArr.Iter((x) => x.transform.position = new Vector3(99999,999999,999999));
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

            go.transform.position = new Vector3(99999, 9999, 99999);
            pool.Enqueue(go);
        }

    }

}
