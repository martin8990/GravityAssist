﻿using UnityEngine;
[System.Serializable]
public struct Biome
{


    [Range(0,1)]    
    public float height;
    [Range(0, 1)]
    public float t;
    [Range(0, 0.4f)]
    public float amplitude;
    [Range(40, 10000)]
    public float smoothness;
    [Range(1000,10000)]
    public float seed;
}