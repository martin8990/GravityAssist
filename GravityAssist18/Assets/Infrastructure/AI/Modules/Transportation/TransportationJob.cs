
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class TransportationJob : Job
    {
        [Range(0,0.1f)]
        public float distModifier = 0.01f;
     
        public int NAssigned;
        public float CoopPenalty = 0.5f;
        public int MaterialsRequested = 10;
        public int MaterialsTransported = 0;

        public override float CalculateUtility(AIUnit aiUnit)
        {
            var dist = Mathf.Min(transform.position.SquareDist2(aiUnit.transform.position) - distModifier,1);
            return aiUnit.transportModule.Priority - dist - CoopPenalty * NAssigned;
        }

        public override void Execute(AIUnit aiUnit, float Period)
        {
            var trans = aiUnit.transportModule;
            var navMeshAgent = aiUnit.navMeshAgent;
            var pos = aiUnit.transform.position;
            if (trans.nMaterials > trans.MinMaterialsForTransport)
            {
                var targetPos = ConstructionHelper.GetClosestWorkSpace(transform, pos);
                if (pos.SquareDist2(targetPos) > aiUnit.DestinationReachedMargin)
                {
                    navMeshAgent.destination = targetPos;
                }
                else
                {
                    navMeshAgent.destination = transform.position;
                    int delta = (int)Mathf.Min(MaterialsRequested - MaterialsTransported, trans.nMaterials);
                    MaterialsTransported += delta;
                    trans.nMaterials -= delta;
                    if (MaterialsTransported == MaterialsRequested)
                    {
                        OnComplete();
                    }
                }

            }
            else
            {
                Stockpile closestSP = TransportationHelper.GetClosestStockPile(aiUnit.stockPiles, transform.position);
                if (closestSP != null)
                {
                    var dest = ConstructionHelper.GetClosestWorkSpace(closestSP.transform,pos);
                    if (pos.SquareDist2(dest) > aiUnit.DestinationReachedMargin)
                    {
                        navMeshAgent.destination = dest;
                    }
                    else
                    {
                        navMeshAgent.destination = pos;
                        int delta = (int)Mathf.Min(new float[] { closestSP.nMaterial, trans.Capacity - trans.nMaterials });
                        
                        closestSP.nMaterial -= delta;
                        trans.nMaterials += delta;
                        
                    }
                }
                else
                {
                    Debug.Log("No stockpile ;(");
                }
            }



        }
        public override void OnComplete()
        {
         
        }
    }

}


