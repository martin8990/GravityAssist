using UnityEngine;
using Utility;
using System.Collections.Generic;



public class WallNode : MonoBehaviour
{
    public GameObject upQuadPrefab;
    public GameObject downQuadPrefab;
    public GameObject rightQuadPrefab;
    public GameObject leftQuadPrefab;
    public GameObject fwdQuadPrefab;
    public GameObject backQuadPrefab;
      

    public void BuildMesh(HashSet<Vector3Int> WallPositions)
    {
        this.DestroyKids();

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        int z = (int)transform.position.z;

        // Left wall
        if (WallPositions.Contains(new Vector3Int(x-1,y,z)))
        {
            BuildFace( leftQuadPrefab);
        }
        // Right wall
        if (WallPositions.Contains(new Vector3Int(x + 1, y, z)))
        {
            BuildFace( rightQuadPrefab);
        }
        // Bottom wall
        if (WallPositions.Contains(new Vector3Int(x, y-1, z)))
        {
            BuildFace( downQuadPrefab);
        }
        // Top wall
        if (WallPositions.Contains(new Vector3Int(x , y+1, z)))
        {
            BuildFace( upQuadPrefab);
        }
        // Back
        if (WallPositions.Contains(new Vector3Int(x , y, z-1)))
        {
            BuildFace( backQuadPrefab);
        }
        // Front
        if (WallPositions.Contains(new Vector3Int(x , y, z+1)))
        {
            BuildFace( fwdQuadPrefab);
        }



    }

    public void BuildFace(GameObject prefab)
    {
        var go = GameObject.Instantiate(prefab, transform, false);
    }
  


}


