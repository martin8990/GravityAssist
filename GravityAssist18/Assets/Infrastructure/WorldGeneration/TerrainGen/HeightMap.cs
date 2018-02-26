using UnityEngine;
[CreateAssetMenu]
public class HeightMap : ScriptableObject
{
    public float[,] heightMap;
    public static implicit operator float[,] (HeightMap hm)
    {
        return hm.heightMap;
    }
}
