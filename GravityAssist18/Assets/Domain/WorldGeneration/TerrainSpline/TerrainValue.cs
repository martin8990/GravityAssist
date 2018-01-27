using UnityEngine;
namespace Domain
{

    public struct TerrainSample
    {
        public float NoiseAmp;
        public float NoiseSmooth;
        public Color color;
        float x;
        float y;
        float z;


    }

    public struct TerrainValue
    {
        public float NoiseAmp;
        public float NoiseSmooth;
        public Color color;
        public float height;

        public TerrainValue(float noiseAmp, float noiseSmooth, Color color, float height)
        {
            NoiseAmp = noiseAmp;
            NoiseSmooth = noiseSmooth;
            this.color = color;
            this.height = height;
        }

        //public static TerrainValue GetFromHeight (float h1,float h2,float h,TerrainValue val1, TerrainValue val2)
        //{
        //    float t = Mathf.InverseLerp(h1, h2, h);
        //    return new TerrainValue(Mathf.Lerp(val1.NoiseAmp, val2.NoiseAmp, t), Mathf.Lerp(val1.NoiseSmooth, val2.NoiseSmooth, t), Color.Lerp(val1.color, val2.color, t));
            
        //}
    }




}
