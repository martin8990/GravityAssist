using UnityEngine;
using System.Collections.Generic;
using Utility;
using UnityEngine.Events;
public class Triggerer : MonoBehaviour
{
    public CIntArr MergeMasks;
    public HashSet<GameObject> TriggeredObjects = new HashSet<GameObject>();
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    private void OnTriggerEnter(Collider other)
    {
        bool enter = false;
        for (int i = 0; i < MergeMasks.val.Length; i++)
        {
            if (other.gameObject.layer == MergeMasks.val[i])
            {
                TriggeredObjects.Add(other.gameObject);
                enter = true;
            }
        }
        if (enter)
        {
            OnEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bool exit = false;

        for (int i = 0; i < MergeMasks.val.Length; i++)
        {
            if (other.gameObject.layer == MergeMasks.val[i])
            {
                TriggeredObjects.Remove(other.gameObject);
                exit = false;
            }
        }
        if (exit)
        {
            OnExit.Invoke();
        }
    }
}


