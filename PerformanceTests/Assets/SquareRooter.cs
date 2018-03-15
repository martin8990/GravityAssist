using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class SquareRooter : MonoBehaviour {

    // Use this for initialization
    public int nTimes;
    public float value = 2.245345f;
    public Text text;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < nTimes; i++)
        {
            Mathf.Sqrt(value);
        }
        sw.Stop();
        text.text = sw.Elapsed.TotalMilliseconds.ToString() + " Ms";
	}
}
