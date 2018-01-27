using UnityEngine;
using Domain;
using Utility;
namespace Infrastructure
{
    public class SplineMarkerCreate : MonoBehaviour
    {
        public GameObject SplineMark_PF;
        
        public SplinePointPositioner pointPositioner;
        public SplineMarkerColorizer colorizer;
        SplinePoint curSP;
        public SplineStorage storage;
        public void CreateNew()
        {
            curSP = SplineFactory.NewSplineMarker(SplineMark_PF, transform, storage.GetCurCont());
        }

        public bool AddPoints(Vector3 Mousepos)
        {
            pointPositioner.PositionKnot(curSP.Knots[0], Mousepos);// 0 = center
            SplineFactory.Smoothen(curSP, storage.GetCurCont().points);

            if (Input.GetMouseButtonDown(0)) 
            {
                colorizer.SetDefaultCol(curSP);
                SplineFactory.AddColliders(curSP);
                SplineFactory.EnableMeshRenderer(curSP);
                CreateNew();
            }

            if (Input.GetMouseButtonDown(1))
            {

                
                storage.GetCurCont().points.RemoveAt(storage.GetCurCont().points.Count - 1);
                GameObject.Destroy(curSP.Knots[0]); // Should get rid of children too

                return false;
            }
            return true;
        }
    }



}
