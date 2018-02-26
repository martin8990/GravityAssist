//using UnityEngine;
//using Utility;
//using UnityEngine.AI;
//using System.Collections;
//using UnityEngine.Events;
//using UnityEngine.UI;
//using System.Collections.Generic;

//namespace Infrastructure
//{
//    public enum ConstructionType
//    {
//        Wall, Floor
//    }

//    public class BuildPlanner : MonoBehaviour
//    {
//        public GameObject BuildPlanPF;
//        public float height = 0.2f;

//        public int CostModifier = 1000;

//        public LayerMask BuildMask;
//        public BuildColors buildColors;
//        public TaskBoard taskboard;

//        public UnityEvent ToBuildController;
        
//        public Text costText;

//        GameObject curGO;
//        Camera cam;
//        Vector3 p1;
//        Vector3 p2;
//        bool Dragging;
//        bool validPos;
//        PositionChecker curPosChecker;
//        BuildJob curBuildJob;
//        TransportationJob curTransJob;
//        public BuildMap buildMap;
 

//        public void Start()
//        {
//            cam = Camera.main;
//        }

//        public void OnCompleteCTORJob(Job job)
//        {
//            buildColors.SetBuild(job.gameObject);
//            job.gameObject.layer = 8;
//            //NavmeshLinkAdder.AddLinks(job.gameObject, job.gameObject.transform.localScale, nvlinkOffset);
//            NavMeshManager.UpdateNavMesh();

//            taskboard.jobs.Remove(job);
//        }

//        public void OnEnable()
//        {
//            curGO = GameObject.Instantiate(BuildPlanPF);
//            curGO.transform.SetParent(transform, false);

//            curTransJob = curGO.GetComponent<TransportationJob>();
//            curTransJob.OnComplete = taskboard.RemoveFromBoard;
//            curBuildJob = curGO.GetComponent<BuildJob>();
//            curBuildJob.OnComplete = OnCompleteCTORJob;
//            curPosChecker = curGO.GetComponent<PositionChecker>();
//        }

//        public void Update()
//        {

//            var pos = Snap.GetSnappedPos(cam, Vector3.one, ~BuildMask);
//            if(curPosChecker.Invalid > 0)
//            {
//                validPos = false;
//                buildColors.SetInvalid(curGO);
//            }
//            else
//            {
//                validPos = true;
//                buildColors.SetPlan(curGO);
//            }
//            if (Input.GetMouseButton(0))
//            {
//                if (!Dragging)
//                {
//                    p1 = pos;
//                    Dragging = true;
//                }
//                if (Dragging)
//                {
//                    p2 = pos;
//                    int x0 = Mathf.FloorToInt(Mathf.Min(p1.x, p2.x));
//                    int x1 = Mathf.FloorToInt(Mathf.Max(p1.x, p2.x));
//                    int z0 = Mathf.FloorToInt(Mathf.Min(p1.z, p2.z));
//                    int z1 = Mathf.FloorToInt(Mathf.Max(p1.z, p2.z));

//                    float cost = 0;
//                    float maxHeight = 0;

//                    for (int x = x0; x < x1; x++)
//                    {
//                        for (int z = z0; z < z1; z++)
//                        {
//                            float terrainHeight = buildMap.GetGameNode(new Vector3(x,0,z)).height;
//                            maxHeight = Mathf.Max(maxHeight, terrainHeight);                     
//                        }
//                    }
//                    float myHeight = maxHeight + height;

//                    for (int x = x0; x < x1; x++)
//                    {
//                        for (int z = z0; z < z1; z++)
//                        {
//                            float terrainHeight = buildMap.GetGameNode(new Vector3(x, 0, z)).height;
//                            cost += Mathf.Max(myHeight - terrainHeight, 0);
//                        }
//                    }
//                    var scale = new Vector3(Mathf.Abs(p2.x - p1.x) + 1, myHeight, Mathf.Abs(p2.z - p1.z) + 1);
//                    curGO.transform.localScale = scale;
//                    curGO.transform.position = new Vector3(p1.x + (p2.x - p1.x) / 2f, myHeight / 2f, p1.z + (p2.z - p1.z) / 2f);
                    
//                    costText.text = "Cost : " + cost;
//                 //   curCTORJob.WorkLeft = cost * CostModifier;
//                    curTransJob.MaterialsRequested = (int)cost * CostModifier; 
//                }
//            }
//            else
//            {
//                if (Dragging)
//                {
//                    Dragging = false;
//                    if (validPos)
//                    {
//                        taskboard.jobs.Add(curTransJob);
//                        taskboard.jobs.Add(curBuildJob);
//                    }
//                    else
//                    {
//                        Destroy(curGO);
//                    }
//                    OnEnable();

//                }
//                else
//                {

               
//                    var h = buildMap.GetGameNode(pos).height;
//                    curGO.transform.position =  new Vector3(pos.x,h,pos.z);
//                    curGO.transform.localScale = new Vector3(1, height, 1);
//                }
//            }
//            if (Input.GetMouseButtonDown(1))
//            {
//                Destroy(curGO);
//                this.enabled = false;
//                ToBuildController.Invoke();
//            }
//            if (Input.GetKeyDown(KeyCode.LeftControl))
//            {
//                height--;
//            }
//            if (Input.GetKeyDown(KeyCode.LeftShift))
//            {
//                height++;
//            }
//            if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl))
//            {
//                //bool deleted = false;
//                //int i = constructionTaskboard.constructionPlans.Count - 1;

//                //while (!deleted && i >= 0)
//                //{
//                //    if (!(constructionTaskboard.constructionPlans[i].constructionStatus == ConstructionStatus.COMPLETE))
//                //    {
//                //        deleted = true;
//                //        var plan = constructionTaskboard.constructionPlans[i];
//                //        constructionTaskboard.constructionPlans.RemoveAt(i);
//                //        Destroy(plan.gameObject);
//                //    }
//                //    else
//                //    {
//                //        i--;
//                //    }
//                //}

//            }
//        }

//    }
//}
