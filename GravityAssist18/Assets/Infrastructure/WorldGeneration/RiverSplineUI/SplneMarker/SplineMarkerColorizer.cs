using UnityEngine;
using Domain;
using System;

namespace Infrastructure
{
    public class SplineMarkerColorizer : MonoBehaviour
    {
        public Color CorrectCol_K;

        public Color HoverCol;


        public Color DefaultCol_K;
        public Color DefaultCol_C;

        public Color InvalidCol_K;


        public void OnCorrectColK(GameObject KnotGO)
        {
            KnotGO.GetComponent<MeshRenderer>().material.color = CorrectCol_K;
        }
        public void OnInvalidCol(GameObject KnotGO)
        {
            KnotGO.GetComponent<MeshRenderer>().material.color = InvalidCol_K;
        }


        public void OnHoverCol(GameObject GO)
        {
            GO.GetComponent<MeshRenderer>().material.color = HoverCol;
        }
        public void ResetColForK_GO(GameObject KnotGO)
        {
            KnotGO.GetComponent<MeshRenderer>().material.color = DefaultCol_K;
        }
          
        public void SetDefaultCol(SplinePoint curSP)
        {
            //defaultKCol(curSP.Knot_Center);
            //DefaultCCol(curSP.Control_IN_GO);
            //DefaultCCol(curSP.Control_OUT_GO);
        }

       
        public void defaultKCol(GameObject C_GO)
        {
            C_GO.GetComponent<MeshRenderer>().material.color = DefaultCol_K;
        }
        public void DefaultCCol(GameObject C_GO)
        {
            C_GO.GetComponent<MeshRenderer>().material.color = DefaultCol_C;
        }


    }



}
