//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using Utility;

//[CreateAssetMenu]
//public class VoxelMap : MonoBehaviour
//{

//    public Node[,,] voxelMap;
//    Camera cam;
//    int myRes;
//    public CInt texRes;
//    public CInt heightLayers;
//    bool ready;
//    public Vector3 MouseVoxel;

//    public float GetHeight(Vector3 Position)
//    {
//        int x = (int)Position.x;
//        int z = (int)Position.z;
//        float maxHeight = 0;
//        for (int y = 0; y < heightLayers; y++)
//        {
//            if (voxelMap[x,y,z].maxHeight < Position.y+0.5f)
//            {
//                maxHeight = Mathf.Max(voxelMap[x, y, z].maxHeight, maxHeight);
//            }
//        }
//        return maxHeight;
//    }
//    public Vector2 GetHeightAndCenter(int x, int z, float minHeight, float maxHeight)
//    {
//        var HnC = new Vector2(maxHeight - minHeight, (minHeight + maxHeight) / 2);
//        for (int y = 0; y < heightLayers; y++)
//        {
//            var minH = voxelMap[x, y, z].minHeight;
//            var maxH = voxelMap[x, y, z].maxHeight;

//            if (minH<maxHeight && maxH > maxHeight)
//            {
//                minHeight = minH;
//            }


//            if (maxH > minHeight && minH < maxHeight)
//            {
//                minHeight = minH;
//            }

//        }
//        return maxHeight;
//    }

//    public void Generate(float[,] heightMap)
//    {

//        myRes = texRes - 1;
//        voxelMap = new Node[myRes, heightLayers, myRes];

//        for (int x = 0; x < myRes; x++)
//        {
//            for (int z = 0; z < myRes; z++)
//            {
//                float maxH = Mathf.Max(new float[]{heightMap[x ,z],
//                    heightMap[x,z],
//                    heightMap[x, z + 1],
//                    heightMap[x + 1, z + 1]
//                    });
//                float minH = Mathf.Min(new float[]{heightMap[x ,z],
//                    heightMap[x,z],
//                    heightMap[x, z + 1],
//                    heightMap[x + 1, z + 1]
//                    });
//                voxelMap[x,0, z] = new Node(minH,maxH,false);
//            }
//        }
//        ready = true;
       
//    }
   
//}


