using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




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