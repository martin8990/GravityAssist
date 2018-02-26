using UnityEngine;
[System.Serializable]
public struct Biome
{


    [Range(0,1)]    
    public float height;
    [Range(0, 1)]
    public float t;
    [Range(0, 0.4f)]
    public float amplitude;
    [Range(40, 1000)]
    public float smoothness;
    [Range(10f,100f)]
    public float seed;
}
