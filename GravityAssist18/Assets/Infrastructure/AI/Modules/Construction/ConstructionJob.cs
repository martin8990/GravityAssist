//using System;
//using UnityEngine;
//using UnityEngine.AI;
//using Utility;

//namespace Infrastructure
//{
    
//    public class ConstructionJob : Job
//    {
//        public int Invalid;
//        public TransportationJob transportationJob;
//        public float WorkLeft = 10;
//        public LayerMask CTORLayers = 8;
    
//        public LayerMask ConstructionLayer;

//        [Range(0, 0.1f)]
//        public float distModifier = 0.01f;
//        public int MinPossibleWork = 5;

//        [HideInInspector]
//        public NavMeshSurface navMesh;
//        public Action<Job> OnComplete;

//        private void OnTriggerEnter(Collider other)
//        {
//            if (other.gameObject.layer == CTORLayers)
//            {
//                Invalid++;
//            }
//        }

//        private void OnTriggerExit(Collider other)
//        {
//            if (other.gameObject.layer == CTORLayers)
//            {
//                Invalid--;
//            }
//        }

    
//        public override float CalculateUtility(AIUnit aiUnit)
//        {
//            if (transportationJob.MaterialsTransported< MinPossibleWork)
//            {
//                return 0;
//            }
//            else
//            {
//                var dist = Mathf.Min(transform.position.SquareDist2(aiUnit.transform.position) * distModifier, 1);
//                var CoopPen = CoopPenalty * nUnitsAssigned;
               
//                return aiUnit.constructionModule.Priority - dist - CoopPenalty * nUnitsAssigned;
//            }

//        }

//        public override void Execute(AIUnit aiUnit, int Period)
//        {
//            var pos = aiUnit.transform.position;
//             aiUnit.workspace = Workspace.GetClosestWorkSpace(wsBuilder.workspaces, pos);
//            if (aiUnit.workspace!=null)
//            {
//                if (pos.SquareDist2(aiUnit.workspace.Position) < aiUnit.DestinationReachedMargin)
//                {
//                    aiUnit.navMeshAgent.destination = pos;
//                    var work = Mathf.Min(aiUnit.constructionModule.WorkPerMs * Period, transportationJob.MaterialsRequested);

//                    transportationJob.MaterialsTransported -= work;
//                    transportationJob.MaterialsRequested -= work;
//                    if (transportationJob.MaterialsRequested == 0)
//                    { 
//                        OnComplete(this);
//                    }

//                }
//                else
//                {
//                    aiUnit.navMeshAgent.destination = aiUnit.workspace.Position;
//                }
//            }
            
//        }
//    }

    

  
//}
