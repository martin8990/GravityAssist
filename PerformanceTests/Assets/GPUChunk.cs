using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;



public class GPUChunk : MonoBehaviour {
	
	public byte[,,] map;
	public Mesh Cube;
    public Material mat;

    public int res = 10;
    public int height = 1;
    public Text text;
    public List<List<Matrix4x4>> voxelMap;

    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;

    // Use this for initialization
    
    private void Start()
    {
        map = new byte[res, height, res];

        for (int x = 0; x < res; x++)
        {
            for (int z = 0; z < res; z++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[x, y, z] = 1;
                }
            }
        }
        voxelMap = CreateVoxelMap();
    }
    // Update is called once per frame
    void Update () {
              

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < voxelMap.Count; i++)
        {
            Graphics.DrawMeshInstanced(Cube, 0, mat, voxelMap[i]);
        }

        stopWatch.Stop();
        
        text.text =  "FrameTime Claimed : " + stopWatch.Elapsed.TotalMilliseconds / 16.6f;
    }


    public List<List<Matrix4x4>> CreateVoxelMap()
    {
        var v1 = new Vector4(1, 0, 0, 0);
        var v2 = new Vector4(0, 1, 0, 0);
        var v3 = new Vector4(0, 0, 1, 0);
        var voxelMap = new List<List<Matrix4x4>>();

        for (int x = 0; x < res; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var voxels = new List<Matrix4x4>();
                for (int z = 0; z < res; z++)
                {
                    if (map[x, y, z] == 0) continue;
                    float prevHeight = 0;
                    for (int i = 0; i < y; i++)
                    {
                        prevHeight += map[x, i, z];
                    }
                    float myHeight = map[x, y, z];

                    var pos = new Vector3(x, prevHeight + myHeight / 2f, z);
                    var matrix = GetFace(up, pos + new Vector3(0,0.5f,0), 1);
                    voxels.Add(matrix);
                    matrix = GetFace(back, pos - new Vector3(0,0,-0.5f), myHeight);

                    voxels.Add(matrix);
                }
                voxelMap.Add(voxels);
            }
        }
        return voxelMap;
    }

    public Matrix4x4 GetFace(Transform dir,Vector4 pos,float height)
    {
        dir.position = pos;
        dir.localScale = new Vector3(1, height, 1);
        var matrix = dir.localToWorldMatrix;

        return matrix;
        
    }

}


