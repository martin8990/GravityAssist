using UnityEngine;
using UnityEngine.AI;
public class NavMeshManager : MonoBehaviour
{
    public static NavMeshSurface navMeshSurface;
    private void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        
    }
    public static void UpdateNavMesh()
    {
        navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
    }
}
