using System.Collections.Generic;
using UnityEngine;
using Domain;

namespace Infrastructure
{
    public class SplineStorage : MonoBehaviour
    {
        
        public List<HeightContour> HeightContours = new List<HeightContour>();
        public GameObject heightContourPF;
        public HeightContour GetCurCont()
        {
           return HeightContours[HeightContours.Count-1];
        }
        public void AddContour()
        {
            var HCGO = GameObject.Instantiate(heightContourPF,transform);
            HCGO.name = "Height Contour " + HeightContours.Count + 1;
            var HC = HCGO.GetComponent<HeightContour>();
            HeightContours.Add(HC);
           
        }



    }

}
