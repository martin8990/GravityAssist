using UnityEngine;
using Utility;
using UnityEngine.AI;
public class LinkSpawner : MonoBehaviour
{
    public GameObject linkPf;
    public Vector2 zRange;
    public int nLinks;
    public NavMeshSurface navMeshSurface;  

    public void Start()
    {
        for (int i = 0; i < nLinks; i++)
        {
            var link = Instantiate(linkPf,transform);
            var p = new Vector3(0, 0, zRange.x + i * (zRange.y - zRange.x) / (float)nLinks);
            link.transform.position = p;

        }
        navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
    }

}
