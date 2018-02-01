using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Domain;
using Utility;
using System.Diagnostics;
public class WorldGenControl : MonoBehaviour
{



    private void Start()
    {
        GenerateWorld();
    }

    [Button]
    public void GenerateWorld()
    {



        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        stopWatch.Stop();
        UnityEngine.Debug.Log(stopWatch.Elapsed.ToString());




    }

}
