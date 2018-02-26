//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using System.Diagnostics;
//using Utility;
//using Infrastructure;

//public class BuildingMatrix : MonoBehaviour
//{

//    public float[,,] map;

//    public GameObject upQuadPrefab;
//    public GameObject downQuadPrefab;
//    public GameObject rightQuadPrefab;
//    public GameObject leftQuadPrefab;
//    public GameObject fwdQuadPrefab;
//    public GameObject backQuadPrefab;
//    public MeshCombiner meshCombinerPrefab;

//    public int res = 10;
//    public int heightRes = 1;

       

//    Dictionary<Vector3Int, GameObject> neighbourLookup = new Dictionary<Vector3Int, GameObject>();

//    void Awake()
//    {
//        map = new float[res, heightRes, res];

//    }


//    public void BuildWall(int wx, int wy, int wz,float blockHeight)
//    {

//        var block = blockHeight;
//        if (IsInRange(wx, wy, wz))
//        {
//            map[wx, wy, wz] = block;
//            for (int x = -1; x <= 1; x++)
//            {
//                for (int y = -1; y <= 1; y++)
//                {
//                    for (int z = -1; z <= 1; z++)
//                    {
//                        if (IsInRange(x+wx, y+wy, z+wz))
//                        {
//                            EvaluateVoxel(x+wx, y+wy, z+wz);
//                        }
//                    }
//                }
//            }

//        }
//        else
//        {
//            UnityEngine.Debug.Log("Error");
//        }
//    }

//    private void EvaluateVoxel(int x, int y, int z)
//    {
//        if (neighbourLookup.ContainsKey(new Vector3Int(x,y,z)))
//        {
//            var go = neighbourLookup[new Vector3Int(x, y, z)];
//            neighbourLookup.Remove(new Vector3Int(x, y, z));
//            Destroy(go);
//        }

//        var myHeight = map[x, y, z];
//        if (myHeight>0)
//        {
//            var p = new Vector3(x, y, z);
//            var dx = Vector3.right;
//            var dy = Vector3.up;
//            var dz = Vector3.forward;
//            MeshCombiner parentGO = null;
//            // Left wall
//            if (IsVisible(x - 1, y, z, myHeight))
//            {
//                BuildFace(p, leftQuadPrefab, ref parentGO);
//            }
//            // Right wall
//            if (IsVisible(x + 1, y, z, myHeight))
//            {
//                BuildFace(p, rightQuadPrefab, ref parentGO);
//            }
//            // Bottom wall
//            if (IsVisible(x, y - 1, z, myHeight))
//            {
//                BuildFace(p, downQuadPrefab, ref parentGO);
//            }
//            // Top wall
//            if (IsVisible(x, y + 1, z, myHeight))
//            {
//                BuildFace(p, upQuadPrefab, ref parentGO);
//            }
//            // Back
//            if (IsVisible(x, y, z - 1, myHeight))
//            {
//                BuildFace(p, backQuadPrefab, ref parentGO);
//            }
//            // Front
//            if (IsVisible(x, y, z + 1, myHeight))
//            {
//                BuildFace(p, fwdQuadPrefab, ref parentGO);
//            }

//            if (parentGO != null)
//            {
//                parentGO.CombineChildren();
//                neighbourLookup.Add(new Vector3Int(x, y, z), parentGO.gameObject);

//            }
//        }        
//    }

//    public void BuildFace(Vector3 position, GameObject prefab,ref MeshCombiner parentGo)
//    {
//        if (parentGo == null)
//        {
//            parentGo = Instantiate(meshCombinerPrefab);
//        }
//        var go = GameObject.Instantiate(prefab,parentGo.transform);
//        go.transform.position = go.transform.position + position;
        
//    }
//    public bool IsVisible(int x, int y, int z, float myHeight)
//    {
//        if (IsInRange(x,y,z))
//        {
//            float otherHeight = map[x, y, z];
//            return myHeight != otherHeight;
//        }
//        return true;
//    }
    
//    public bool IsInRange(int x, int y, int z)
//    {
//        if ((x < 0) || (y < 0) || (z < 0) || (y >= heightRes) || (x >= res) || (z >= res))
//        {
//            return false;
//        }
//        else
//        {
//            return true;
//        }
//    }
//}


