using System;
using UnityEngine;
[System.Serializable]
public struct Spline
{
   public  Vector3 K_1;
    public Vector3 C_Out_1;
    public Vector3 C_In_2;
    public Vector3 K_2;

    public Vector3 SampleSpline(float t)
    {
        float t1 = 1f - t;
        float t2 = t1*t1;
        float t3 = t1 * t1 * t1;


        var P =
         t3 * K_1
        + 3 * t2 * t * C_Out_1
        + 3 * t1 * t * t * C_In_2
        + t * t * t * K_2;
        return P;
    }

    public Vector3 GetTangent(float t)
    {
        var tangent =
            K_1 * (-(1 - t) * (1 - t)) +
            C_Out_1 * (t * (3 * t - 4) + 1) +
            C_In_2 * (-3 * t * t + 2 * t) +
            K_2 * t * t;
        return tangent.normalized;
    }

    public float[] GetSamples(int nSamples)
    {
        // Get distance between samples
        // lerp to find actual values
        float totalDistance = 0;
        float[] distanceTbl = new float[nSamples + 1]; 
        var prevp = SampleSpline(0);
        distanceTbl[0] = 0;
        for (int i = 1; i <= nSamples; i++)
        {
            float t = (float)i / (float)nSamples;
            var p = SampleSpline(t);
            var dist = Vector3.Distance(prevp, p);
            totalDistance += dist;
            distanceTbl[i] = totalDistance;
            prevp = p;
        }

        float delta = totalDistance / (nSamples);
        float[] samples = new float[nSamples];
        samples[0] = 0;
        for (int i = 1; i < nSamples; i++)
        {
            float myDist = i * delta;
//            Debug.Log("MyDist : " + myDist + "Total : " + totalDistance);
            int j = 0;
            while (j+1 < distanceTbl.Length-1 && distanceTbl[j+1] < myDist)
            {
                j++;
            }
            float t = (myDist - distanceTbl[j]) / (distanceTbl[j + 1] - distanceTbl[j]);
            samples[i] = Mathf.Lerp((float)j/nSamples, (float)(j+1)/nSamples, t);
        }
        return samples;
    }
    

    public Vector3 GetNormal(float t, Vector3 up)
    {
        var tng = GetTangent(t);
        Vector3 binormal = Vector3.Cross(up, tng).normalized;
        return Vector3.Cross(tng, binormal);
    }
    public Vector3 Get2DNormal(float t, Vector3 up)
    {
        var tng = GetTangent(t);
        Vector3 binormal = Vector3.Cross(up, new Vector3(tng.x,0,tng.z)).normalized;
        return Vector3.Cross(tng, binormal);
    }

    public Quaternion GetOrientation(float t)
    {
        Vector3 tng = GetTangent(t);
        Vector3 nrm = GetNormal(t, Vector3.up);
        return Quaternion.LookRotation(tng, nrm);
    }
}
