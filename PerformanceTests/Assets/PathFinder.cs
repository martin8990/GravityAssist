using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PathFinder : MonoBehaviour {
    NavMeshAgent meshAgent;
    public Transform dest;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }	

	void Update () {
        meshAgent.SetDestination(dest.position);		
	}
}
