﻿
using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class TransportationJob : Job
    {
        [Range(0,0.1f)]
        public float distModifier = 0.01f;

        public Action<Job> OnComplete;  
        public int MaterialsRequested = 10;
        public int MaterialsTransported = 0;

        public override float CalculateUtility(AIUnit aiUnit)
        {
            if (nUnitsAssigned == CoopMax)
            {
                return 0;
            }
            else
            {
                var dist = Mathf.Min(transform.position.SquareDist2(aiUnit.transform.position) * distModifier, 1);
                var CoopPen = CoopPenalty * nUnitsAssigned;
                return aiUnit.transportModule.Priority - dist - CoopPenalty * nUnitsAssigned;
            }

        }

        public override void Execute(AIUnit aiUnit, int Period)
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
                    navMeshAgent.destination = pos;
                    int delta = (int)Mathf.Min(MaterialsRequested - MaterialsTransported, trans.nMaterials);
                    MaterialsTransported += delta;
                    trans.nMaterials -= delta;
                    if (MaterialsTransported == MaterialsRequested)
                    {
                        OnComplete(this);
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
       
    }

}


