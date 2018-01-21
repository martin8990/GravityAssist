using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using UnityEngine.AI;
public class WorldCreator : MonoBehaviour {


    public CInt MapSize;
    public GameObject planePF;
    GameObject[,] planes;
    [Button]
    public void CreateWorld()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        planes =  WorldFactory.BuildPlanes(0,planePF,transform,MapSize);
    }
    [Button]
    public void AddNavmesh()
    {
        var navMeshSurfaces = planes.Map2D1D((x) => x.AddComponent<NavMeshSurface>());
        navMeshSurfaces.Iter((x) => x.BuildNavMesh());
    }


}
