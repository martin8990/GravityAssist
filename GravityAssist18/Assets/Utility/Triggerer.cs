﻿using UnityEngine;
using System.Collections.Generic;
using Utility;
using UnityEngine.Events;
public class Triggerer : MonoBehaviour
{
    public int[] filterMasks;
    public List<GameObject> TriggeredObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < filterMasks.Length; i++)
        {
            if (other.gameObject.layer == filterMasks[i])
            {
                TriggeredObjects.Add(other.gameObject);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        for (int i = 0; i < filterMasks.Length; i++)
        {
            if (other.gameObject.layer == filterMasks[i])
            {
                TriggeredObjects.Remove(other.gameObject);

            }
        }

    }
    public static Triggerer AddSphereTrigger(Transform parent, string name, float range, int[] masks)
    {
        var GO = new GameObject(name);
        GO.transform.SetParent(parent, false);
        var col = GO.AddComponent<SphereCollider>();
        col.radius = range;
        col.isTrigger = true;
        GO.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        var trigger = GO.AddComponent<Triggerer>();
        trigger.filterMasks = masks;
        return trigger;

    }
    public static Triggerer AddSphereTrigger(Transform parent, string name, float range, int[] masks, int myLayer)
    {
        var GO = new GameObject(name);
        GO.transform.SetParent(parent, false);
        GO.layer = myLayer;
        var col = GO.AddComponent<SphereCollider>();
        col.radius = range;
        col.isTrigger = true;
        GO.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        var trigger = GO.AddComponent<Triggerer>();
        trigger.filterMasks = masks;
       
        return trigger;

    }

    public List<T> GetComponentsInTrigger<T>() where T : Component
    {
        var result = new List<T>();
        for (int i = 0; i < TriggeredObjects.Count; i++)
        {
            if (TriggeredObjects[i] != null)
            {
                result.Add(TriggeredObjects[i].GetComponent<T>());
            }
        }
        return result;
    }
    int i = 0;
    public void Update()
    {
        if (i < TriggeredObjects.Count)
        {
            if (TriggeredObjects[i] == null)
            {
                TriggeredObjects.RemoveAt(i);
            }
            if (i == TriggeredObjects.Count-1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
        else
        {
            i = 0;
        }

        
    }
}


