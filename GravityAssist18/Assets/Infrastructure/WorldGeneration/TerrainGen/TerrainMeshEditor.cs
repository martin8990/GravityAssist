﻿using UnityEngine;
using UnityEngine.UI;
using Utility;
using System.Collections;
using System.Collections.Generic;

public class TerrainMeshEditor : MonoBehaviour
{
    public CInt drawDistance;
    public CInt texRes;

    public Material planeMaterial;
    public CInt meshRes;

    public int normalsPerFrame;
    public int updatesPerFrame;

    public GameObject[,] planes;

    public IEnumerator GenerateTerrain(float[] heightMap)
    {

        meshRes.val = texRes / drawDistance;
        planes = new GameObject[drawDistance, drawDistance];
        int cnt = 0;
        for (int x = 0; x < drawDistance; x++)
        {
            for (int z = 0; z < drawDistance; z++)
            {
                var GO = PlaneGen.GeneratePlane(meshRes, planeMaterial, heightMap, new Vector2Int(x, z), texRes);
                GO.transform.SetParent(transform);
                GO.transform.position = new Vector3((x+0.5f) * meshRes , 0, (z+0.5f) * meshRes );
                GO.name = "Plane x : " + x + " z : " + z;
                planes[x, z] = GO;
                cnt++;
                if (cnt == normalsPerFrame)
                {
              
                    cnt = 0;
                    yield return null;
                }
            }
        }

    }

    public IEnumerator UpdateHeight(GameObject[,] planes, float[] heigthMap)
    {
        int l = planes.GetLength(0);
        int cnt = 0;
        for (int x = 0; x < l; x++)
        {
            for (int z = 0; z < l; z++)
            {
                PlaneGen.UpdateHeight(meshRes,heigthMap,planes[x, z], new Vector2Int(x,z),texRes);
                cnt++;
                if (cnt == updatesPerFrame)
                {
                    yield return null;
                    cnt = 0;
                }

            }
        }

    }
    public IEnumerator UpdateNormals(GameObject[,] planes)
    {
        int cnt = 0;
        int l = planes.GetLength(0);
        for (int x = 0; x < l; x++)
        {
            for (int y = 0; y < l; y++)
            {
                PlaneGen.UpdateNormals( planes[x, y]);
               
                 
                cnt++;
                if (cnt == normalsPerFrame)
                {

                    cnt = 0;
                    yield return null;
                }

            }
        }
    }

    //public IEnumerator UpdateMesh()
    //{
    //    int l = planes.GetLength(0);
    //    for (int x = 0; x < l; x++)
    //    {
    //        for (int y = 0; y < l; y++)
    //        {
    //            PlaneGen.UpdatePlane(vertices, planes[x, y]);
    //            yield return null;
    //        }
    //    }
    //    StartCoroutine(UpdateMesh());
    //}
}