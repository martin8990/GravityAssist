using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utility;
namespace Infrastructure
{

    public class TransportAI : AIModule
    {
        public List<Stockpile> stockpiles;
        public TransportationTaskboard taskboard;
        public int nMaterials;
        public int MinMaterialsForTransport;
        public int Capacity;


        public override void Execute(float period)
        {
            if (taskboard.transportationTasks.Count>0)
            {
                var positions = taskboard.transportationTasks.Map((x) => x.transform.position);
                int bestPos = transform.position.GetNearestTargetId(positions);
                var curPlan = taskboard.transportationTasks[bestPos];


                if (nMaterials > MinMaterialsForTransport)
                {

                    var targetPos = ConstructionHelper.GetClosestWorkSpace(curPlan.transform, transform.position);
                    if (transform.position.SquareDist2(targetPos) > DestinationReachedMargin)
                    {
                        navMeshAgent.destination = targetPos;
                    }
                    else
                    {
                        navMeshAgent.destination = transform.position;
                        int delta = (int)Mathf.Min(curPlan.WorkLeft - curPlan.Material, nMaterials);
                        curPlan.Material += delta;
                        nMaterials -= delta;
                    }

                }
                else
                {
                    Stockpile closestSP = TransportationHelper.GetClosestStockPile(stockpiles, transform.position);
                    if (closestSP != null)
                    {
                        var dest = ConstructionHelper.GetClosestWorkSpace(closestSP.transform, transform.position);
                        if (transform.position.SquareDist2(dest) > DestinationReachedMargin)
                        {
                            navMeshAgent.destination = dest;
                        }
                        else
                        {
                            navMeshAgent.destination = transform.position;
                            int delta = (int)Mathf.Min(new float[] { closestSP.nMaterial, Capacity - nMaterials });
                            closestSP.nMaterial -= delta;
                            nMaterials += delta;
                            Debug.Log("delta");
                        }
                    }
                    else
                    {
                        Debug.Log("No stockpile ;(");
                    }
                }
            }
            
        }

    }
}




