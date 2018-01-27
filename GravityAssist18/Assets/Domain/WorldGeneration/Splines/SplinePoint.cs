using System;
using UnityEngine;
using Utility;
namespace Domain
{

    public class SplinePoint : MonoBehaviour
    {
        public GameObject[] Knots = new GameObject[3];
        public GameObject[] CTRL_IN_x = new GameObject[3];
        public GameObject[] CTRL_OUT_x = new GameObject[3];
        public GameObject[] CTRL_y = new GameObject[4];

        public Vector3 Knot_Center
        {
            get { return Knots[0].transform.position; }
            set { Knots[0].transform.position = value; }
        }
        public Vector3 Knot_Left
        {
            get { return Knots[1].transform.position; }
            set { Knots[1].transform.position = value; }
        }
        public Vector3 Knot_Right
        {
            get { return Knots[2].transform.position; }
            set { Knots[2].transform.position = value; }
        }

        public Vector3[] Knot_ARR
        {
            get { return new Vector3[3] { Knot_Center, Knot_Left, Knot_Right }; }
            set { Knot_Center = value[0]; Knot_Left = value[1]; Knot_Right = value[2]; }
        }
        
        public Vector3 CTRL_IN_x_Center
        {
            get { return CTRL_IN_x[0].transform.position; }
            set { CTRL_IN_x[0].transform.position = value; }
        }
        public Vector3 CTRL_IN_x_Left
        {
            get { return CTRL_IN_x[1].transform.position; }
            set { CTRL_IN_x[1].transform.position = value; }
        }
        public Vector3 CTRL_IN_x_Right
        {
            get { return CTRL_IN_x[2].transform.position; }
            set { CTRL_IN_x[2].transform.position = value; }
        }
        
        public Vector3[] CTRL_IN_x_ARR
        {
            get { return new Vector3[3] { CTRL_IN_x_Center, CTRL_IN_x_Left, CTRL_IN_x_Right }; }
            set { CTRL_IN_x_Center = value[0]; CTRL_IN_x_Left = value[1]; CTRL_IN_x_Right = value[2];}
        }


        public Vector3 CTRL_OUT_x_Center
        {
            get { return CTRL_OUT_x[0].transform.position; }
            set { CTRL_OUT_x[0].transform.position = value; }
        }
        public Vector3 CTRL_OUT_x_Left
        {
            get { return CTRL_OUT_x[1].transform.position; }
            set { CTRL_OUT_x[1].transform.position = value; }
        }
        public Vector3 CTRL_OUT_x_Right
        {
            get { return CTRL_OUT_x[2].transform.position; }
            set { CTRL_OUT_x[2].transform.position = value; }
        }

        public Vector3[] CTRL_OUT_x_ARR
        {
            get { return new Vector3[3] { CTRL_OUT_x_Center, CTRL_OUT_x_Left, CTRL_OUT_x_Right }; }
            set { CTRL_OUT_x_Center = value[0]; CTRL_OUT_x_Left = value[1]; CTRL_OUT_x_Right = value[2]; }
        }

        public Vector3 CTRL_y_LEFT
        {
            get { return CTRL_y[0].transform.position; }
            set { CTRL_y[0].transform.position = value; }
        }
        public Vector3 CTRL_y_Center_Left
        {
            get { return CTRL_y[1].transform.position; }
            set { CTRL_y[1].transform.position = value; }
        }
        public Vector3 CTRL_y_Center_Right
        {
            get { return CTRL_y[2].transform.position; }
            set { CTRL_y[2].transform.position = value; }
        }
        public Vector3 CTRL_y_Right
        {
            get { return CTRL_y[3].transform.position; }
            set { CTRL_y[3].transform.position = value; }
        }
        
    }
}
