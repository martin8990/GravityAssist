//using UnityEngine;
//using UnityEngine.AI;
//using Utility;
//namespace Infrastructure
//{


//    public class ConstructionAI : AIModule
//    {
//        public ConstructionLibrary constructionLibrary;
//        public ConstructionPlan curPlan;


//        public int nMaterials = 0;
//        public int CarryingCapacity = 50;
//        public float minDistUntilDestReached = 1f;
//        public int WorkToDoBeforeOutOfMat = 5;
//        public int WorkPerSec = 10;
//        NavMeshAgent navMeshAgent;

//        Material mat;


//        public override bool Trigger(float period)
//        {
//            curPlan = ConstructionHelper.ChoosePlan(ref curPlan, constructionLibrary, transform.position);

//            if (curPlan != null)
//            {

//                if (curPlan.Material > WorkToDoBeforeOutOfMat && curPlan.Material - WorkToDoBeforeOutOfMat > 0)
//                {
//                    var ws = GetClosestWorkSpace(curPlan.transform, transform.position);
//                    if (transform.position.SquareDist2(ws) > minDistUntilDestReached)
//                    {
//                        navMeshAgent.destination = ws;
//                    }
//                    else
//                    {
//                        navMeshAgent.destination = transform.position;
//                        curPlan.WorkLeft -= WorkPerSec * period;
//                        curPlan.Material -= (int)(WorkPerSec * period);
//                        if (curPlan.WorkLeft < 0)
//                        {
//                            curPlan.onComplete();
//                            curPlan = null;
//                            Debug.Log("Done");
//                        }
//                    }

//                }
//                else
//                {


//                }
//                return true;
//            }
//            else
//            {
//                //  navMeshAgent.destination = GetClosestStockPile().transform.position;
//                return false;
//            }
//        }




        

//    }



//}


