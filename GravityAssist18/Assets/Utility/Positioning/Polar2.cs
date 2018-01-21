using UnityEngine;


namespace Utility
{
    public struct Polar2
    {
        public float r;
        public float phi;

        public Polar2(float r, float phi)
        {
            this.r = r;
            this.phi = phi;
        }

        public Polar2(Vector2 cart)
        {
            this.r = Mathf.Sqrt(cart.x * cart.x + cart.y * cart.y);
            this.phi = Mathf.Atan(cart.y / cart.x);
        }


        public static implicit operator Vector2(Polar2 pol)
        {
            return new Vector2(pol.r * Mathf.Cos(pol.phi), pol.r * Mathf.Sin(pol.phi));
        }
        public static implicit operator Polar2(Vector2 cart)
        {
            return new Polar2(Mathf.Sqrt(cart.x * cart.x + cart.y * cart.y), Mathf.Atan(cart.y / cart.x));
        }

    }
}
