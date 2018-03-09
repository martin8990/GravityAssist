using UnityEngine;
using System.Collections.Generic;
using Utility;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
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
        GO.transform.parent.SetParent(parent, false);
        var col = GO.AddComponent<SphereCollider>();
        col.radius = range;
        col.isTrigger = true;
        GO.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        var trigger = GO.AddComponent<Triggerer>();
        trigger.filterMasks = masks;
        return trigger;

    }

}


