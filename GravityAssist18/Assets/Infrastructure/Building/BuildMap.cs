using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utility;


public class BuildMap : MonoBehaviour
{

    public GameNode[,] map;
    public CInt texRes;
    bool ready;
    int myRes;
    public GameObject debugObj;

    public GameNode GetGameNode(Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x);
        int z = Mathf.FloorToInt(pos.z);

        return map[x, z];
    }


    public void Generate(float[] heightMap)
    {

        myRes = texRes - 1;
        map = new GameNode[myRes, myRes];

        for (int x = 0; x < myRes; x++)
        {
            for (int z = 0; z < myRes; z++)
            {
                float h = Mathf.Max(new float[]{heightMap[x + z * texRes],
                    heightMap[x + 1 + z * texRes],
                    heightMap[x + (z + 1) * texRes],
                    heightMap[x + 1 + (z + 1) * texRes]
                    });
                map[x, z] = new GameNode(h, NodeType.free);
            }
        }
        ready = true;
       
    }
    public void FreeWorkspace(Vector3 pos)
    {
        map[(int)pos.x, (int)pos.z].nodeType = NodeType.free;
    }

    public Vector3 GetClosestWorkspace(GameObject Block,GameObject AiUnit)
    {
        var pos = Block.transform.position;
        var scl = Block.transform.localScale;

        int xMin = (int)(pos.x - scl.x / 2 - 1);
        int xMax = (int)(pos.x + scl.x / 2 + 1);

        int zMin = (int)(pos.z - scl.z / 2 - 1);
        int zMax = (int)(pos.z + scl.z / 2 + 1);

        var wspaces = new List<Vector3>();

        for (int x = xMin; x < xMax; x++)
        {
            if (map[x,zMin].nodeType == NodeType.free)
            {
                wspaces.Add(new Vector3( x - 0.5f,map[x,zMin].height, zMin - 0.5f));
                
            }
            if (map[x, zMax].nodeType == NodeType.free)
            {
                wspaces.Add(new Vector3(x - 0.5f, map[x, zMax].height, zMax - 0.5f));
            }
        }
        for (int z = zMin; z < zMax; z++)
        {
            if (map[xMin, z].nodeType == NodeType.free)
            {
                wspaces.Add(new Vector3(xMin - 0.5f, map[xMin, z].height, z - 0.5f));

            }
            if (map[xMax, z].nodeType == NodeType.free)
            {
                wspaces.Add(new Vector3(xMax - 0.5f, map[xMax, z].height, z - 0.5f));
            }
        }
        float minDist = Mathf.Infinity;
        Vector3 bestWs = Vector3.zero;
        for (int i = 0; i < wspaces.Count; i++)
        {
            float dist = AiUnit.transform.position.SquareDist2(wspaces[i]);
            if (dist<minDist)
            {
                minDist = dist;
                bestWs = wspaces[i];
            }
        }
        map[(int)bestWs.x, (int)bestWs.z].nodeType = NodeType.reserved;
        return bestWs;


    }

    public void SetBuildPlan(GameObject buildPlan)
    {
        var scl = buildPlan.transform.localScale;
        var pos = buildPlan.transform.position;
        var xmin = (int)(pos.x - scl.x / 2);
        var xmax = (int)(pos.x + scl.x / 2);
        var zmin = (int)(pos.z - scl.z / 2);
        var zmax = (int)(pos.z + scl.z / 2);
        int height = (int)scl.y;

        for (int x = xmin; x < xmax; x++)
        {
            for (int z = zmin; z < zmax; z++)
            {
                map[x, z] = new GameNode(height, NodeType.reserved);
            }
        }

                
    }





   

}


