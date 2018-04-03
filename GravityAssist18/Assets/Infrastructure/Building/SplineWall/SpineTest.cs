using UnityEngine;

namespace Infrastructure
{
    public class SpineTest : MonoBehaviour
    {
        public Spline spline;
        public int nSamples;
        public float offset;
        private void OnDrawGizmosSelected()
        {
            var samples = spline.GetSamples(nSamples);
            for (int i = 0; i < nSamples; i++)
            {
                float t = samples[i];
                Gizmos.DrawCube(spline.SampleSpline(t), Vector3.one);
                Gizmos.DrawCube(spline.SampleSpline(t) + spline.Get2DNormal(t , Vector3.right) * offset, Vector3.one) ;
                Gizmos.DrawCube(spline.SampleSpline(t) - spline.Get2DNormal(t, Vector3.right) * offset, Vector3.one);

            }
        }

    }
}
