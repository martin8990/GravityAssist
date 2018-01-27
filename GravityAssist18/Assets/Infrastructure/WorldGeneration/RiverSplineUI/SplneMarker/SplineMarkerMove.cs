using UnityEngine;
using Utility;
using System.Collections.Generic;
namespace Infrastructure
{
    public class SplineMarkerMove : MonoBehaviour
    {

        GameObject KnotGO;
        GameObject CtrlGO;
        GameObject ClickedKnotGO;
        Vector3 prevPos;
        public SplineMarkerColorizer colorizer;
        public SplinePointPositioner positioner;
        public void HoverOrMove(Vector3 MousePos)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (KnotGO != null)
                    {
                        KnotGO.GetComponent<SphereCollider>().enabled = false;
                        positioner.VerticallyPositionK(KnotGO, MousePos,prevPos);
                        KnotGO.GetComponent<SphereCollider>().enabled = true;
                    }
                }
                else
                {
                    if (KnotGO != null)
                    {
                        KnotGO.GetComponent<SphereCollider>().enabled = false;
                        positioner.PositionKnot(KnotGO, MousePos);
                        KnotGO.GetComponent<SphereCollider>().enabled = true;
                        if (ClickedKnotGO == null || KnotGO!=ClickedKnotGO)
                        {
                            if (ClickedKnotGO != null && KnotGO != ClickedKnotGO)
                            {
                                for (int i = 0; i < ClickedKnotGO.transform.childCount; i++)
                                {
                                    var go = ClickedKnotGO.transform.GetChild(i);
                                    if (go.tag == "CTRL")
                                    {
                                        go.GetComponent<MeshRenderer>().enabled = false;
                                        go.GetComponent<SphereCollider>().enabled = false;
                                    }
                                }
                            }
                            ClickedKnotGO = KnotGO;
                            for (int i = 0; i < ClickedKnotGO.transform.childCount; i++)
                            {
                                var go = ClickedKnotGO.transform.GetChild(i);
                                if (go.tag == "CTRL")
                                {
                                    go.GetComponent<MeshRenderer>().enabled = true;
                                    go.GetComponent<SphereCollider>().enabled = true;
                                }
                            }
                        }

                    }
                    else if (CtrlGO != null)
                    {
                        CtrlGO.GetComponent<SphereCollider>().enabled = false;
                        positioner.PositionCTRL(CtrlGO, MousePos);
                        CtrlGO.GetComponent<SphereCollider>().enabled = true;
                    }
                }
            }
            else
            {
                var Go = positioner.FindGameobjectOnPos(MousePos);
                if (Go!=null)
                {
                    if (Go.tag == positioner.KnotTag)
                    {
                        KnotGO = Go;
                        colorizer.OnHoverCol(KnotGO);
                    }
                    else if (Go.tag == positioner.CTRLTag)
                    {
                        CtrlGO = Go;
                        colorizer.OnHoverCol(CtrlGO);
                    }
                    else
                    {
                        if (KnotGO != null)
                        {
                            colorizer.ResetColForK_GO(KnotGO);
                            KnotGO = null;
                        }
                        if (CtrlGO != null)
                        {
                            colorizer.DefaultCCol(CtrlGO);
                            CtrlGO = null;
                        }
                    }
                }
               

            }
            prevPos = MousePos;
        }
    }
   


}
