using UnityEngine;
using Domain;
using Utility;
namespace Infrastructure
{
    public class SplineSampler : MonoBehaviour
    {
        public int nSamps;
        public SplineSample[] SampleSpline(SplinePoint start , SplinePoint finish)
        {


            var samples = new SplineSample[nSamps];
            for (int i = 0; i < nSamps; i++)
            {
                float t = (float)nSamps / (float)i;
                var pos = new IntVector3(SplineCalc.CalcXPos(t, start, finish));
                samples[i] = new SplineSample(pos);
            }        

            return samples;
        }

    }
   


}
