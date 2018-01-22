using Infrastructure;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PathFinderManager : MonoBehaviour
{
    public Pathfinder[] pathFinders;
    public float updateTime = 2.0f;

    private void Start()
    {

    }

    public void SetTarget(Transform target)
    {
        pathFinders.Iter((x) => x.destination = target);
        pathFinders.Iter((x) => x.FindPath());
    }

    // every 2 seconds perform the print()
    private System.Collections.IEnumerator UpdatePath()
    {

        yield return new WaitForSeconds(updateTime);
        pathFinders.Iter((x) => x.FindPath());
        StartCoroutine(UpdatePath());
    }



}
