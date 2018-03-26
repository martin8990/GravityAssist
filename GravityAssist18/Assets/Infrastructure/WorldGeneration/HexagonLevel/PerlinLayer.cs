using UnityEngine;

namespace Infrastructure
{
    [System.Serializable]
    public class PerlinLayer
    {

        [Range(0f, 1f)]
        public float frequency;
        [Range(0f,1f)]
        public float threshHold;
        [Range(10000f, 1000000f)]

        public float Seed;
        public bool inLayer(float x, float y)
        {

         //   Debug.Log(Mathf.PerlinNoise(x * frequency + Seed + 0.01f, y * frequency +  Seed + 0.01f) + " X :  " + x  + " Y :  "+ y);
           return threshHold < Mathf.PerlinNoise(x * frequency + Seed + 0.01f, y * frequency + Seed + 0.01f);
        }
    }
    
}


