using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Domain
{
    public static class SplineCalc
    {
        public static Vector3 CalcGeneric(float t, Vector3[] vectors)
        {
            float t3 = Mathf.Pow(1f - t, 3);
            float t2 = Mathf.Pow(1f - t, 2);
            float t1 = 1f - t;

            Vector3 P =
              vectors[0] * t3
            + vectors[1] * 3 * t2 * t
            + vectors[2] * 3 * t1 * t * t
            + vectors[3] * t * t * t;
            return P;
        }

        public static Vector3 CalcXPos(float t, SplinePoint start, SplinePoint finish)
        {
            float t3 = Mathf.Pow(1f - t, 3);
            float t2 = Mathf.Pow(1f - t, 2);
            float t1 = 1f - t;

            Vector3 P =
              start.Knot_Center* t3
            + start.CTRL_OUT_x_Center * 3 * t2 * t
            + finish.CTRL_IN_x_Center * 3 * t1 * t * t
            + finish.Knot_Center * t * t * t;
            return P;
        }
        public static Vector3 CalcYPos(float t, SplinePoint p)
        {
            t = t * 2;
          
            if (t<1)
            {
                

                float t3 = Mathf.Pow(1f - t, 3);
                float t2 = Mathf.Pow(1f - t, 2);
                float t1 = 1f - t;

                Vector3 P =
                  p.Knot_Left * t3
                + p.CTRL_y_LEFT * 3 * t2 * t
                + p.CTRL_y_Center_Left * 3 * t1 * t * t
                + p.Knot_Center* t * t * t;
                return P;
            }
            else
            {
                t = t - 1f;
                float t3 = Mathf.Pow(1f - t, 3);
                float t2 = Mathf.Pow(1f - t, 2);
                float t1 = 1f - t;

                Vector3 P =
                  p.Knot_Center * t3
                + p.CTRL_y_Center_Right * 3 * t2 * t
                + p.CTRL_y_Right * 3 * t1 * t * t
                + p.Knot_Right * t * t * t;
                return P;
            }
        }

    }
}
