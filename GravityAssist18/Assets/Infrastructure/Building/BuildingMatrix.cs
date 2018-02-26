using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using Utility;
using Infrastructure;

public class BuildingMatrix : MonoBehaviour
{

    public byte[,,] map;

    public int res = 10;
    public int heightRes = 1;

    public Dictionary<int, Matrix4x4> lookup = new Dictionary<int, Matrix4x4>();
    public GPUFaceInstancer faceInstancer;

    void Awake()
    {
        map = new byte[res, heightRes, res];
    }

    public void UpdateRangeHeight(Vector2Int xRange, Vector2Int yRange, Vector2Int zRange, byte newType)
    {
        for (int x = xRange.x; x < xRange.y; x++)
        {
            for (int y = yRange.x; y < yRange.y; y++)
            {
                for (int z = zRange.x; z < zRange.y; z++)
                {
                    if (IsInRange(x,y,z))
                    {
                        map[x, y, z] = newType;
                    }
                }                
            }
        }

        for (int x = xRange.x-1; x < xRange.y+1; x++)
        {
            for (int y = yRange.x-1; y < yRange.y+1; y++)
            {
                for (int z = zRange.x-1; z < zRange.y+1; z++)
                {

                    if (IsInRange(x , y , z ))
                    {
                        UpdateVoxel(x , y , z);
                    }


                }

            }
        }
     
        faceInstancer.updateFaceTransform(lookup);       

       


    }

    private void UpdateVoxel(int x, int y, int z)
    {

        var myHeight = map[x, y, z];
        int BaseId = 6 * x + y * res * 6 + z * res * heightRes * 6;
        RemoveAllPreviousIds(BaseId);
        if (myHeight > 0)
        {
            var p = new Vector3(x, y, z);

            int id = BaseId;
            var pos = Vector3.zero;
            var rot = Vector3.zero;
            var scl = Vector3.zero;


            // Left
            if (IsVisible(x - 1, y, z, myHeight))
            {
                id = BaseId;
                pos = new Vector3(p.x - .5f, y, z);
                rot = new Vector3(0, -0.5f * Mathf.PI, 0);
                scl = new Vector3(1, myHeight, 1);

                lookup.Add(id, TransFormer.GetTransform(pos, scl, rot));

            }
            //Right
            if (IsVisible(x + 1, y, z, myHeight))
            {
                id = BaseId + 1;
                pos = new Vector3(p.x + .5f, y, z);
                rot = new Vector3(0, 0.5f * Mathf.PI, 0);
                scl = new Vector3(1, myHeight, 1);
                lookup.Add(id, TransFormer.GetTransform(pos, scl, rot));

            }
            if (IsVisible(x, y - 1, z, myHeight))
            {
                id = BaseId + 2;
                pos = new Vector3(p.x, y - .5f, z);
                rot = new Vector3(0.5f * Mathf.PI, 0, 0);
                scl = new Vector3(1, myHeight, 1);
                lookup.Add(id, TransFormer.GetTransform(pos, scl, rot));

            }
            if (IsVisible(x, y + 1, z, myHeight))
            {
                id = BaseId + 3;
                pos = new Vector3(p.x, y + .5f, z);
                rot = new Vector3(-0.5f * Mathf.PI, 0, 0);
                scl = new Vector3(1, myHeight, 1);
                lookup.Add(id, TransFormer.GetTransform(pos, scl, rot));

            }
            // Back
            if (IsVisible(x, y, z - 1, myHeight))
            {
                id = BaseId + 4;
                pos = new Vector3(p.x, y, z - .5f);
                rot = new Vector3(0, 0, 0);
                scl = new Vector3(1, myHeight, 1);
                lookup.Add(id, TransFormer.GetTransform(pos, scl, rot));
            }
            // Front
            if (IsVisible(x, y, z + 1, myHeight))
            {
                id = BaseId + 5;
                pos = new Vector3(p.x, y, z + .5f);
                rot = new Vector3(0, -Mathf.PI, 0);
                scl = new Vector3(1, myHeight, 1);
                lookup.Add(id, TransFormer.GetTransform(pos, scl, rot));
            }


        }
    }




    void RemoveAllPreviousIds(int baseId)
    {
        for (int i = 0; i < 6; i++)
        {
            if (lookup.ContainsKey(baseId + i))
            {
                lookup.Remove(baseId + i);
            }

        }

    }


    public bool IsVisible(int x, int y, int z, float myHeight)
    {
        if (IsInRange(x, y, z))
        {
            return map[x, y, z] == 0;
        }
        return true;
    }

    public bool IsInRange(int x, int y, int z)
    {
        if ((x < 0) || (y < 0) || (z < 0) || (y >= heightRes) || (x >= res) || (z >= res))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}


