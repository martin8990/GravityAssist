using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utility;



public class ConstructionMatrix : MonoBehaviour
{

    public GameNode[,,] map;
    [HideInInspector]

    public CInt texRes;
    public int heightLayers = 5;
    public WallType wallType;
    bool ready;
    // Use this for initialization

    public void Generate(float[] heightMap)
    {
        

        map = new GameNode[texRes, heightLayers, texRes];

        int myRes = texRes - 1;
        for (int x = 0; x < myRes; x++)
        {
            for (int z = 0; z < myRes; z++)
            {
                int h = Mathf.FloorToInt((heightMap[x + z * texRes] +
                    heightMap[x + 1 + z * texRes] +
                    heightMap[x + (z + 1) * texRes] +
                    heightMap[x + 1 + (z + 1) * texRes]
                    ) / 4f);
                map[x,0, z] = new GameNode(h,NodeType.Terrain);
            }
        }

        for (int x = 50; x < 150; x++)
        {
            for (int z = 100; z < 150; z++)
            {
                map[x, 1, z] = new GameNode(30 - map[x, 0, z].height, NodeType.Wall);
            }
        }
        ready = true;
        
    }

    private void Update()
    {
        if (ready)
        {
            wallType.CreateVisualMesh(map);

        }
    }


    //public void CreateMatrix (int _width, int _height, float[] heightMap, Vector2Int offset, int texRes,float maxHeight) {

    //       width = _width;
    //       meshRenderer = GetComponent<MeshRenderer>();
    //	meshCollider = GetComponent<MeshCollider>();
    //	meshFilter = GetComponent<MeshFilter>();

    //       map = new int[width, heightLayers, width];

    //	for (int x = 0; x < width; x++)
    //	{
    //		for (int z = 0; z < width; z++)
    //		{
    //               int h = Mathf.FloorToInt((heightMap[x + z * texRes] +
    //                   heightMap[x + 1 + z * texRes] +
    //                   heightMap[x + (z + 1) * texRes] +
    //                   heightMap[x + 1 + (z + 1) * texRes]
    //                   ) / 4f);
    //               map[x, 0, z] = h;

    //		}
    //	}

    //	CreateVisualMesh();

    //}

    // Update is called once per frame



    //public virtual bool IsTransparent (int x, int y, int z)
    //{
    //	byte brick = GetByte(x,y,z);
    //	switch (brick)
    //	{
    //	default:
    //	case 0: 
    //		return true;

    //	case 1: return false;
    //	}
    //}
    ////public virtual byte GetByte (int x, int y , int z)
    //{
    //	if ( (x < 0) || (y < 0) || (z < 0) || (y >= heightLayers) || (x >= width) || (z >= width))
    //		return 0;
    //	return map[x,y,z];
    //}

}


