﻿using UnityEngine;
using Utility;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Infrastructure
{

    public class CubeMaker : MonoBehaviour
    {

        public GameObject cubePF;
        GameObject curGO;
        public GameObject linkPF;
        Camera cam;
        Vector3 p1;
        Vector3 p2;
        public float height = 1f;
        bool Dragging;
        bool validPos;
        public float nvlinkOffset = 1f;
        public NavMeshSurface navMeshSurface;
        public PathFinderManager finderManager;
        public UnityEvent done;
        public LayerMask cubeMask;
        public CubeColors cubeColors;


        public void Start()
        {
            cam = Camera.main;
        }
        public void OnEnable()
        {
            curGO = GameObject.Instantiate(cubePF);
            curGO.transform.SetParent(transform, false);
                  
        }
        
        public void Update()
        {
            var pos = Snap.GetSnappedPos(cam, Vector3.one,~cubeMask);
            if (curGO.GetComponent<CubePlan>().Invalid>0)
            {
                validPos = false;
                cubeColors.SetInvalid(curGO);
            }
            else
            {
                validPos = true;
                cubeColors.SetPlan(curGO);
            }
            if (Input.GetMouseButton(0))
            {
                if (!Dragging)
                {
                    p1 = pos;
                    Dragging = true;
                }
                if (Dragging)
                {
                    p2 = pos;
                    var scale = new Vector3(Mathf.Abs(p2.x - p1.x) + 1, height, Mathf.Abs(p2.z - p1.z) + 1);
                    curGO.transform.localScale = scale;
                    curGO.transform.position = new Vector3(p1.x + (p2.x - p1.x) /2f , height/2f + pos.y, p1.z + (p2.z - p1.z)/2f);
                    curGO.GetComponent<CubePlan>().WorkLeft = scale.x * scale.y * scale.z; 
                }
            }
            else
            {
                if (Dragging)
                {
                    Dragging = false;
                    if (validPos)
                    {
                        NavmeshLinkAdder.AddLinks(curGO, curGO.transform.localScale, nvlinkOffset);
                        navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
                        
                    }
                    else
                    {
                        Destroy(curGO);
                    }
                    OnEnable();
                 
                }
                else
                {
                    curGO.transform.position = new Vector3(pos.x,height/2f + pos.y, pos.z);
                    curGO.transform.localScale = new Vector3(1, height, 1);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(curGO);
                this.enabled = false;
                done.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                height--;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                height++;
            }
        }
              
    }
}
