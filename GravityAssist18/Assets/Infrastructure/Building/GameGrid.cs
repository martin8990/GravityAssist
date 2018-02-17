//using UnityEngine;
//using Utility;

//public class GameGrid : MonoBehaviour
//{

//    public CInt TexRes;
//    public CInt drawDistance;
//    public static GameNode[,] gameGrid;

//    public void CreateGrid(float[] heightMap)
//    {
//        int myRes = TexRes-1;
//        gameGrid = new GameNode[myRes, myRes];
//        for (int x = 0; x < myRes; x++)
//        {
//            for (int z = 0; z < myRes; z++)
//            {
//                int h = Mathf.FloorToInt((heightMap[x + z * TexRes] +
//                    heightMap[x + 1+ z * TexRes] + 
//                    heightMap[x  + (z+1) * TexRes] + 
//                    heightMap[x + 1 + (z+1) * TexRes]
//                    )/4f);
//                gameGrid[x, z] = new GameNode(h);
//            }
//        } 
//    }

//    public static void ChangeNodeTypes(Vector2Int min, Vector2Int max, NodeType nodeType)
//    {
//        for (int x = min.x; x < max.x; x++)
//        {
//            for (int y = min.y; y < max.y; y++)
//            {
//                gameGrid[x, y].nodeType = nodeType;
//            }
//        }
//    }
//    public static void ChangeHeight(Vector2Int min, Vector2Int max,int height)
//    {
//        for (int x = min.x; x < max.x; x++)
//        {
//            for (int y = min.y; y < max.y; y++)
//            {
//                gameGrid[x, y].height = height;
//            }
//        }
//    }

//    private void OnDrawGizmosSelected()
//    {
//        if (gameGrid!=null)
//        {
//            Gizmos.color = Color.white;
//            gameGrid.Iteri2D_((x, z, gn) => Gizmos.DrawCube(new Vector3(x + 0.5f, gn.height - 0.5f, z+0.5f), Vector3.one));
//        }
//    }
//}



