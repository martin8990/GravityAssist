using UnityEngine;
using Utility;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Infrastructure
{
    public enum ConstructionType
    {
        Wall,Floor
    }

    public class Architect : MonoBehaviour
    {
        public GameObject CTORPlanPF;
        public int height = 1;
   
        public int CostModifier = 1000; 
        
        public LayerMask CTORMask;
        public ConstructionColors cubeColors;
        public TaskBoard taskboard;

        public UnityEvent ToBuildController;
        
        public ConstructionType constructionType;
        public Text costText;
        
        GameObject curGO;
        Camera cam;
        Vector3 p1;
        Vector3 p2;
        bool Dragging;
        bool validPos;
        ConstructionJob curCTORJob;
        TransportationJob curTransJob;
    
   
        public void Start()
        {
            cam = Camera.main;
        }

        public void OnCompleteCTORJob(Job job)
        {
            cubeColors.SetBuild(job.gameObject);
            job.gameObject.layer = 8;
        //    NavmeshLinkAdder.AddLinks(job.gameObject, job.gameObject.transform.localScale, nvlinkOffset);
            NavMeshManager.UpdateNavMesh();
            
            taskboard.jobs.Remove(job);
        }

        public void OnEnable()
        {
            curGO = GameObject.Instantiate(CTORPlanPF);
            curGO.transform.SetParent(transform, false);

            curTransJob = curGO.GetComponent<TransportationJob>();
            curTransJob.OnComplete = taskboard.RemoveFromBoard;
            curCTORJob = curGO.GetComponent<ConstructionJob>();
            curCTORJob.OnComplete = OnCompleteCTORJob;
        }
        
        public void Update()
        {
            var pos = Snap.GetSnappedPos(cam, Vector3.one,~CTORMask);
            if (curCTORJob.Invalid>0)
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
                    curGO.transform.position = new Vector3(p1.x + (p2.x - p1.x) / 2f, height / 2f, p1.z + (p2.z - p1.z) / 2f);
                    int x0 = (int)Mathf.Min(p1.x, p2.x);
                    int x1 = (int)Mathf.Max(p1.x, p2.x);
                    int z0 = (int)Mathf.Min(p1.z, p2.z);
                    int z1 = (int)Mathf.Max(p1.z, p2.z);

                    float cost = 0;
                    int minHeight = height;
                    for (int x = x0; x< x1; x++)
                    {
                        for (int z = z0; z < z1; z++)
                        {
                            float ggHeight = GameGrid.gameGrid[x, z].height;
                            cost += Mathf.Max(height - ggHeight,0);
                            if (ggHeight < minHeight)
                            {
                                minHeight = (int)ggHeight;
                            }
                        }
                    }
                    GameGrid.ChangeNodeTypes(new Vector2Int(x0, x1), new Vector2Int(z0, z1), NodeType.BuildPos);

                    costText.text = "Cost : " + cost;
                    curCTORJob.WorkLeft = cost * CostModifier;
                    curTransJob.MaterialsRequested = (int)curCTORJob.WorkLeft;                   
                }
            }
            else
            {
                if (Dragging)
                {
                    Dragging = false;
                    if (validPos)
                    {
                        taskboard.jobs.Add(curTransJob);
                        taskboard.jobs.Add(curCTORJob);
                    }
                    else
                    {
                        Destroy(curGO);
                    }
                    OnEnable();
                 
                }
                else
                {
                    height = (int)pos.y;
                    curGO.transform.position = new Vector3(pos.x,height/2f, pos.z);
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
                //bool deleted = false;
                //int i = constructionTaskboard.constructionPlans.Count-1;
                
                //while (!deleted && i>=0)
                //{
                //    if (!(constructionTaskboard.constructionPlans[i].constructionStatus == ConstructionStatus.COMPLETE))
                //    {
                //        deleted = true;
                //        var plan = constructionTaskboard.constructionPlans[i]; 
                //        constructionTaskboard.constructionPlans.RemoveAt(i);
                //        Destroy(plan.gameObject);
                //    }
                //    else
                //    {
                //        i--;
                //    }
                //}

            }
        }
              
    }
}
