using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;
namespace Domain
{
    public static class SplineFactory
    {
        public static SplinePoint NewSplineMarker(GameObject SplineMarkPF, Transform prnt, HeightContour heightContour)
        {
            var SP_GO = GameObject.Instantiate(SplineMarkPF, prnt);
            var SP = SP_GO.GetComponent<SplinePoint>();


            if (heightContour.points.Count == 0)
            {
                ArrayIter.Iter(SP.CTRL_OUT_x, (x) => x.SetActive(false));
                ArrayIter.Iter(SP.CTRL_IN_x, (x) => x.SetActive(false));
            }
            else
            {
                var prev = heightContour.points[heightContour.points.Count - 1];
                ArrayIter.Iter(prev.CTRL_OUT_x, (x) => x.SetActive(true));
                ArrayIter.Iter(SP.CTRL_OUT_x, (x) => x.SetActive(false));

            }

            heightContour.points.Add(SP);
            SP_GO.transform.SetParent(heightContour.transform);

            
           

            return SP;
        }
        public static void AddColliders(SplinePoint splinePoint)
        {
            ArrayIter.Iter<GameObject>(splinePoint.Knots, (x) => x.GetComponent<SphereCollider>().enabled = true);
            //ArrayIter.Iter<GameObject>(splinePoint.CTRL_IN_x, (x) => x.GetComponent<SphereCollider>().enabled = true);
            //ArrayIter.Iter<GameObject>(splinePoint.CTRL_OUT_x, (x) => x.GetComponent<SphereCollider>().enabled = true);
            //ArrayIter.Iter<GameObject>(splinePoint.CTRL_y, (x) => x.GetComponent<SphereCollider>().enabled = true);




            //SphereCollider[] cols = {
            //splinePoint.Knot_Center.AddComponent<SphereCollider>(),
            //splinePoint.Control_IN_GO.AddComponent<SphereCollider>(),
            //splinePoint.Control_OUT_GO.AddComponent<SphereCollider>()
            //};
            //Action<SphereCollider>[] acts = { (x) => x.radius = 2 };
            //ArrayIter.Iter<SphereCollider>(cols, acts);

        }
        public static void EnableMeshRenderer(SplinePoint splinePoint)
        {
            //MeshRenderer[] mrs = {            
            //splinePoint.Control_IN_GO.GetComponent<MeshRenderer>(),
            //splinePoint.Control_OUT_GO.GetComponent<MeshRenderer>()
            //};
            //Action<MeshRenderer>[] acts = { (x) => x.enabled = true };
            //ArrayIter.Iter<MeshRenderer>(mrs, acts);

        }

        
        public static void Smoothen(SplinePoint point, List<SplinePoint> points)
        {
          
            int id = points.Count - 1;

            if (id > 1)
            {
                var prev_1 = points[id - 1];
                var prev_2 = points[id - 2];

                var delta = ArrayMap.Map2(point.Knot_ARR,prev_2.Knot_ARR,(x,y) => x-y); // Not prev_1 on purpose
                prev_1.CTRL_IN_x_ARR = ArrayMap.Map2(prev_1.Knot_ARR,delta, (x,y) => x - 0.5f * y);
                prev_1.CTRL_OUT_x_ARR = ArrayMap.Map2(prev_1.Knot_ARR, delta, (x, y) => x + 0.5f * y);
                                
            }

        }

       
    }
}
