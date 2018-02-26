using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MultiCubes : MonoBehaviour {

    public int nCubes;
    public GameObject cube;
    public Text text;
    // Use this for initialization
    List<GameObject> gameObjects = new List<GameObject>();

    private void Update()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            Destroy(gameObjects[i]);
        }
        gameObjects = new List<GameObject>();
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < nCubes; i++)
        {
            gameObjects.Add(GameObject.Instantiate(cube));
        }    
        stopWatch.Stop();

        text.text = "FrameTime Claimed : " + stopWatch.Elapsed.TotalMilliseconds / 16.6f;
    }


}
