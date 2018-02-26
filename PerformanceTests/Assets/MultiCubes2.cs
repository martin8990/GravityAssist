using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class MultiCubes2 : MonoBehaviour {

    public int nCubes;
    public GameObject cube;
    public Text text;
    public GameobjectPool pool;
    // Use this for initialization
    List<GameObject> gameObjects = new List<GameObject>();

    private void Update()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            pool.ReturnToPool(gameObjects[i]);
        }
        gameObjects = new List<GameObject>();
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < nCubes; i++)
        {
            var go = pool.GetFromPool();
            go.transform.position =new Vector3(0, i, 0);
            gameObjects.Add(go);
        }    
        stopWatch.Stop();

        text.text = "FrameTime Claimed : " + stopWatch.Elapsed.TotalMilliseconds / 16.6f;
    }


}
