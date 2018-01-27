
using System;
using UnityEngine;
namespace Utility
{

    public struct Polar3
    {
        public float r;
        public float h;
        public float phi;

        public Polar3(float r, float h, float phi)
        {
            this.r = r;
            this.h = h;
            this.phi = phi;
            
        }

        public Polar3(Vector3 cart)
        {
            this.r = Mathf.Sqrt(cart.x * cart.x + cart.z * cart.z);
            this.h = cart.y;
            this.phi = Mathf.Atan2(cart.z , cart.x);
        }

        public Vector3 toCart()
        {
           return new Vector3(r * Mathf.Cos(phi),h, r * Mathf.Sin(phi));
        }
        public static Polar3 operator * (float val, Polar3 pol1)
        {
            return new Polar3(val * pol1.r, val * pol1.h, val * pol1.phi);
        }

        public static Polar3 operator + (Polar3 pol1, Polar3 pol2)
        {
            return new Polar3(pol1.r + pol2.r,pol1.h+  pol2.h, pol1.phi + pol2.phi);
        }

        public static implicit operator Vector3(Polar3 pol3)
        {
            return new Vector3(pol3.r, pol3.h, pol3.phi);
        }

        public static Polar3 Lerp(Polar3 startPos, Polar3 Finish, float t)
        {
            return (1 - t) * startPos + t * Finish;

        }
        public static Polar3 rTAprox(Polar3 start, Polar3 finish, float r)
        {
            var t = (r - start.r) / (finish.r - start.r);
            return Lerp(start, finish, t);
        }

        public static Polar3 SplineCalc(float t,Polar3[] Polars)
        {
            float t3 = Mathf.Pow(1f - t, 3);
            float t2 = Mathf.Pow(1f - t, 2);
            float t1 = 1f - t;

            Polar3 P =
             t3 * Polars[0] 
            + 3 * t2 * t * Polars[1]
            +  3 * t1 * t * t * Polars[2] 
            +  t * t * t * Polars[3];
            return P;
        }


    }
}
