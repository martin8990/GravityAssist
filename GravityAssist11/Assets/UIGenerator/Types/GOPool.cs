using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GOPool
{
    public Queue<GameObject> pool = new Queue<GameObject>();
    public List<GameObject> active = new List<GameObject>();
    public int count;
    Transform PoolParent;
    public GOPool(Transform parent, int count,GameObject prefab)
    {
        var Pool = new List<GameObject>();
        PoolParent = parent;
        for (int i = 0; i < count; i++)
        {
            var GO = GameObject.Instantiate(prefab);
            GO.transform.SetParent(parent, false);
            GO.SetActive(false);
            pool.Enqueue(GO);
        }
    }
    public List<T> GetComponents<T>() where T : Component
    {
        var Components = ComponentsGetter.GetFromGOS<T>(pool.ToList());
        return Components;
    }
    public void returnAll()
    {
        foreach (var GO in active)
        {
            GO.transform.SetParent(PoolParent);
            GO.SetActive(false);
            pool.Enqueue(GO);

        }
    }
    public List<GameObject> GetFromPool(int count)
    {
 
        if (pool.Count>0)
        {
            var GO = pool.Dequeue();
            GO.SetActive(true);
            active.Add(GO);
            
        }
        else
        {
            Debug.Log("Pool is empty");
        }
        return active;
        
    }

}

