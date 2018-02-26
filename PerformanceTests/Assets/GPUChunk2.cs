using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
public class GPUChunk2 : MonoBehaviour {
	
    public Material mat;
    
    public int nCubes;
    public Text text;
    // Use this for initialization

    private void Start()
    {
       

    }

    void OnRenderObject()
    {
        mat.SetPass(0);
        mat.SetMatrix("My_Object2World", transform.localToWorldMatrix);
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Graphics.DrawProcedural(MeshTopology.Triangles, 6 * 8, nCubes);

        stopWatch.Stop();

        text.text = "FrameTime Claimed : " + stopWatch.Elapsed.TotalMilliseconds / 16.6f;
    }

    
   


}


