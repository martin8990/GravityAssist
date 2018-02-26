using UnityEngine;
using Utility;
using System.Collections.Generic;
public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab;
    public CInt MapSize;
    public Vector2Int[,] grid;

    public Queue<Vector2Int> randomCoordQueue;
    public int seed;

    public int NObjects;
    public List<GameObject> randomObjects;
    bool gizmos;

    [Button]
    public void CreateGrid()
    {
        grid = ArrayInit.iInit2D(MapSize+1, MapSize+1, (x, y) => new Vector2Int(x - MapSize/2, y - MapSize / 2));
                     
    }
    [Button]
    public void CreateRandomCoords()
    {
        var AllCoords = grid.Map2D1D((x) => x);
        AllCoords.Shuffle(seed);
        randomCoordQueue = new Queue<Vector2Int>(AllCoords);
    }
    
    [Button]
    public void PlaceObjectsAtRandom()
    {
        this.DestroyKids();
        randomObjects = new List<GameObject>();
        for (int i = 0; i < NObjects; i++)
        {
            var go = GameObject.Instantiate(objectPrefab);
            go.transform.parent = this.transform;
            var coord = randomCoordQueue.Dequeue();
            go.transform.position = new Vector3(coord.x, 0, coord.y);
            randomObjects.Add(go);
        }

    }

    [Button]
    public void ToggleGizmos()
    {
        gizmos = !gizmos;
    }


    public void OnDrawGizmos()
    {
        if (grid!=null && gizmos)
        {
            Gizmos.color = Color.green;
            grid.Iter2D((x) => Gizmos.DrawCube(new Vector3(x.x, 0, x.y),Vector3.one));
        }
    }


}