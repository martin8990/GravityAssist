using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utility;
namespace Infrastructure
{

    public class ConstructionAI : AIModule
    {
        public ConstructionLibrary constructionLibrary;
        public ConstructionPlan curPlan;
        public List<Stockpile> stockpiles;
        public CubeColors cubeColors;

        public int nMaterials = 0;
        public int CarryingCapacity = 50;
        public float minDistUntilDestReached = 1f;
        public float WorkToDoBeforeOutOfMat = 5;
        public float WorkPerSec = 10;
        NavMeshAgent navMeshAgent;
        public int enemyNear;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }



        public override void Trigger(float period)
        {

            if (curPlan == null)
            {
                int cnt = constructionLibrary.constructionPlans.Count;
                int i = cnt - 1;

                while (i >= 0 && curPlan == null)
                {
                    var plan = constructionLibrary.constructionPlans[i];
                    if (plan.constructionStatus != ConstructionStatus.COMPLETE)
                    {
                        curPlan = plan;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            else
            {
            
                if (curPlan.Material > WorkToDoBeforeOutOfMat && curPlan.Material - WorkToDoBeforeOutOfMat > 0)
                {
                    
                        if (transform.position.SquareDist2(curPlan.transform.position) > minDistUntilDestReached)
                        {
                            navMeshAgent.destination = curPlan.transform.position;
                        }
                        else
                        {
                            navMeshAgent.destination = transform.position;
                            curPlan.WorkLeft -= WorkPerSec * period;
                            curPlan.Material -= (int)(WorkPerSec * period);
                            if (curPlan.WorkLeft < 0)
                            {
                                curPlan.constructionStatus = ConstructionStatus.COMPLETE;
                                cubeColors.SetBuild(curPlan.gameObject);
                                curPlan = null;
                            }
                        }
                   
                }
                else
                {
                    Stockpile closestSP = null;
                    float mindist = 1000000;
                    if (nMaterials < WorkToDoBeforeOutOfMat)
                    {
                        foreach (var stockpile in stockpiles)
                        {
                            float dist = transform.position.SquareDist2(stockpile.transform.position);
                            if (dist < mindist && stockpile.nMaterial > 0)
                            {
                                closestSP = stockpile;
                                mindist = dist;
                            }
                        }
                        if (closestSP != null)
                        {
                            // Debug.Log("minDist " + minDistUntilDestReached + " ,SquareDist " + transform.position.SquareDist2(closestSP.transform.position));
                            if (transform.position.SquareDist2(closestSP.transform.position) > minDistUntilDestReached)
                            {
                                navMeshAgent.destination = closestSP.transform.position;
                            }
                            else
                            {
                                navMeshAgent.destination = transform.position;
                                int delta = (int)Mathf.Min(new float[] { closestSP.nMaterial, CarryingCapacity - nMaterials });
                                closestSP.nMaterial -= delta;
                                nMaterials += delta;
                                Debug.Log("delta " + delta);

                            }
                        }
                        else
                        {
                            Debug.Log("No stockpile ;(");
                        }
                    }
                    else
                    {
                        if (transform.position.SquareDist2(curPlan.transform.position) > minDistUntilDestReached)
                        {
                            navMeshAgent.destination = curPlan.transform.position;
                        }
                        else
                        {
                            navMeshAgent.destination = transform.position;
                            int delta = (int)Mathf.Min(curPlan.WorkLeft - curPlan.Material, nMaterials);
                            curPlan.Material += delta;
                            nMaterials -= delta;
                        }
                    }
                   
                }
            }
        }
    }


}


