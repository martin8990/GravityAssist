using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MultiCubes3 : MonoBehaviour {

    public int nCubes;
    public GameObject cube;
    public Text text;
    // Use this for initialization
    List<GameObject> gameObjects = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < nCubes; i++)
        {
            var go = GameObject.Instantiate(cube);
            cube.transform.position = new Vector3(0, i, 0);
        }
    }



}
