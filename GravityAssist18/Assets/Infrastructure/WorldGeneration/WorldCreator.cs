using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
public class WorldCreator : MonoBehaviour {


    public CInt MapSize;
    public GameObject planePF;

    [Button]
    public void CreateWorld()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        var planes =  WorldFactory.BuildPlanes(0,planePF,transform,MapSize);
    }

    
}
