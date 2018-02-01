using UnityEngine;
[System.Serializable]
public struct HeightContour
{
 
    public Vector2 center;
    public float smoothness;
    public float fractals;
    public float seed;
    public int nCPoints;
    
};

[System.Serializable]
public struct ContourPoint
{
    [Range(0, 800)]
    public float radius;
    [Range(0, 1)]
    public float height;
    [Range(-Mathf.PI,Mathf.PI)]
    public float angle;
    [Range(0, 1)]
    public float NoiseAmp;
};



