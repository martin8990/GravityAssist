using UnityEngine;
using Utility;
namespace Infrastructure
{
    public static class ConstructionHelper
    {

        public static Vector3 GetClosestWorkSpace(Transform square, Vector3 myPos)
        {
            var WorkScale = square.localScale;
            var WorkPos = square.position;

            if (WorkScale.x > WorkScale.z)
            {
                var p1 = WorkPos + new Vector3(0, 0, WorkScale.z / 2);
                var p2 = WorkPos - new Vector3(0, 0, WorkScale.z / 2);

                if (myPos.SquareDist2(p1) < myPos.SquareDist2(p2))
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
            else
            {
                var p1 = WorkPos + new Vector3(WorkScale.x / 2, 0, 0);
                var p2 = WorkPos - new Vector3(WorkScale.x / 2, 0, 0);
                if (myPos.SquareDist2(p1) < myPos.SquareDist2(p2))
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
        }

        public static ConstructionPlan ChoosePlan(ref ConstructionPlan curPlan, ConstructionTaskBoard constructionLibrary, Vector3 pos)
        {
            if (curPlan != null && curPlan.constructionStatus == ConstructionStatus.COMPLETE)
            {
                curPlan = null;
                Debug.Log("Already done");
            }
            int cnt = constructionLibrary.constructionPlans.Count;
            int i = cnt - 1;

            float curdist = 10000000;
            if (curPlan != null)
            {
                curdist = pos.SquareDist2(curPlan.transform.position);
            }

            foreach (var plan in constructionLibrary.constructionPlans)
            {
                if (plan.constructionStatus != ConstructionStatus.COMPLETE)
                {
                    var dist = pos.SquareDist2(plan.transform.position);
                    if (dist < curdist)
                    {
                        curdist = dist;
                        curPlan = plan;
                    }
                }
            }
            return curPlan;
        }
    }



}


