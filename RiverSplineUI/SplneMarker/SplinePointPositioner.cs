using UnityEngine;
using Utility;

namespace Infrastructure
{
    public class SplinePointPositioner : MonoBehaviour
    {
        public SplineMarkerColorizer colorizer;
        public Camera cam;
        public float HeightPadding;
        public float vertSensitivity = 0.01f;
        public string TerrainTag;
        public string KnotTag;
        public string CTRLTag;
        public string FirstKnotTag;

        public void PositionKnot(GameObject knotGo, Vector3 pos)
        {
            RaycastHit Hit;
            var isHit = MousePositioning.VerticalRayCast(pos, 100, out Hit);
            if (isHit)
            {
                if (Hit.collider.gameObject.tag == TerrainTag)
                {
                    knotGo.transform.position = Hit.point + new Vector3(0, HeightPadding, 0);
                    colorizer.OnCorrectColK(knotGo);
                }

            }
        }
        public void VerticallyPositionK(GameObject knotGo, Vector3 pos, Vector3 prevPos)
        {
            knotGo.transform.position =
                knotGo.transform.position + new Vector3(0,vertSensitivity * Mathf.Pow(pos.x, 2) - Mathf.Pow(prevPos.x, 2) + Mathf.Pow(pos.z, 2) - Mathf.Pow(prevPos.z,2), 0);
        }


        public bool PositionCTRL(GameObject CtrlGO, Vector3 pos)
        {
            RaycastHit Hit;
            var isHit = MousePositioning.VerticalRayCast(pos, 100, out Hit);
            if (isHit)
            {

                CtrlGO.transform.position = Hit.point;
                    
                    return true;
                
            }
            return false;
        }

        public GameObject FindGameobjectOnPos(Vector3 pos)
        {
            RaycastHit Hit;
            var isHit = MousePositioning.VerticalRayCast(pos, 100, out Hit);
            if (isHit)
            {
                return Hit.collider.gameObject;
            }
            return null;
        }
    }



}
