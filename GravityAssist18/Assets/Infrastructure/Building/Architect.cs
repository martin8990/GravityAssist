﻿using UnityEngine;
using Utility;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.Events;

namespace Infrastructure
{


    public class Architect : MonoBehaviour
    {

        public GameObject CTORPlanPF;
        public float height = 1f;
        public float nvlinkOffset = 1f;
        
        public LayerMask CTORMask;
        public ConstructionColors cubeColors;
        public ConstructionTaskBoard constructionTaskboard;
        public TransportationTaskboard transportationTaskboard;

        public UnityEvent ToBuildController;
        public NavMeshSurface navMesh;

        GameObject curGO;
        Camera cam;
        Vector3 p1;
        Vector3 p2;
        bool Dragging;
        bool validPos;

        public void Start()
        {
            cam = Camera.main;
        }
        public void OnEnable()
        {
            curGO = GameObject.Instantiate(CTORPlanPF);
            curGO.transform.SetParent(transform, false);
            curGO.GetComponent<ConstructionPlan>().navMesh = navMesh;
                  
        }
        
        public void Update()
        {
            var pos = Snap.GetSnappedPos(cam, Vector3.one,~CTORMask);
            if (curGO.GetComponent<ConstructionPlan>().Invalid>0)
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
                    curGO.GetComponent<ConstructionPlan>().WorkLeft = scale.x * scale.y * scale.z; 
                }
            }
            else
            {
                if (Dragging)
                {
                    Dragging = false;
                    if (validPos)
                    {
                        
                        constructionTaskboard.constructionPlans.Add(curGO.GetComponent<ConstructionPlan>());
                        transportationTaskboard.transportationTasks.Add(curGO.GetComponent<ConstructionPlan>());
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
                ToBuildController.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                height--;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                height++;
            }
            if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl))
            {
                bool deleted = false;
                int i = constructionTaskboard.constructionPlans.Count-1;
                
                while (!deleted && i>=0)
                {
                    if (!(constructionTaskboard.constructionPlans[i].constructionStatus == ConstructionStatus.COMPLETE))
                    {
                        deleted = true;
                        var plan = constructionTaskboard.constructionPlans[i]; 
                        constructionTaskboard.constructionPlans.RemoveAt(i);
                        Destroy(plan.gameObject);
                    }
                    else
                    {
                        i--;
                    }
                }

            }
        }
              
    }
}
