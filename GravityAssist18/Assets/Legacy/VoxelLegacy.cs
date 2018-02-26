using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//public Vector3 GetClosestWorkspace(GameObject Block,GameObject AiUnit)
//{
//    //var pos = Block.transform.position;
//    //var scl = Block.transform.localScale;

//    //int xMin = (int)(pos.x - scl.x / 2 - 1);
//    //int xMax = (int)(pos.x + scl.x / 2 + 1);

//    //int zMin = (int)(pos.z - scl.z / 2 - 1);
//    //int zMax = (int)(pos.z + scl.z / 2 + 1);

//    //var wspaces = new List<Vector3>();

//    //for (int x = xMin; x < xMax; x++)
//    //{
//    //    if (voxelMap[x,zMin].nodeType == NodeType.free)
//    //    {
//    //        wspaces.Add(new Vector3( x - 0.5f,voxelMap[x,zMin].height, zMin - 0.5f));

//    //    }
//    //    if (voxelMap[x, zMax].nodeType == NodeType.free)
//    //    {
//    //        wspaces.Add(new Vector3(x - 0.5f, voxelMap[x, zMax].height, zMax - 0.5f));
//    //    }
//    //}
//    //for (int z = zMin; z < zMax; z++)
//    //{
//    //    if (voxelMap[xMin, z].nodeType == NodeType.free)
//    //    {
//    //        wspaces.Add(new Vector3(xMin - 0.5f, voxelMap[xMin, z].height, z - 0.5f));

//    //    }
//    //    if (voxelMap[xMax, z].nodeType == NodeType.free)
//    //    {
//    //        wspaces.Add(new Vector3(xMax - 0.5f, voxelMap[xMax, z].height, z - 0.5f));
//    //    }
//    //}
//    //float minDist = Mathf.Infinity;
//    //Vector3 bestWs = Vector3.zero;
//    //for (int i = 0; i < wspaces.Count; i++)
//    //{
//    //    float dist = AiUnit.transform.position.SquareDist2(wspaces[i]);
//    //    if (dist<minDist)
//    //    {
//    //        minDist = dist;
//    //        bestWs = wspaces[i];
//    //    }
//    //}
//    //voxelMap[(int)bestWs.x, (int)bestWs.z].nodeType = NodeType.reserved;
//    //return bestWs;


//}



class VoxelLegacy
    {
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