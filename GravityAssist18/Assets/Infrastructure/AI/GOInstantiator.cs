using UnityEngine;
using Utility;
using UnityEngine.AI;
namespace Infrastructure
{
    public class GOInstantiator : MonoBehaviour
    {
        public GameObject prefab;
        public Vector3 size;
        public Vector2 CubePos;
        public Pathfinder[] Pathfinders;
        public NavMeshSurface nms;
        public float offset = 1;
        [Button]
        public void go()
        {
            var go = GameObject.Instantiate(prefab,transform);
            go.transform.localScale = size;
            go.transform.position = new Vector3(CubePos.x,size.y/2f,CubePos.y);


            nms.UpdateNavMesh(nms.navMeshData);


            var target = go.GetComponentInChildren<Transform>();
            Pathfinders.Iter((x) => x.destination = target);
            Pathfinders.Iter((x) => x.FindPath());
            NavmeshLinkAdder.AddLinks(go, size, offset);
         
         

        }
    }
}

public static class NavmeshLinkAdder
{
    public static void AddLinks(GameObject go, Vector3 size,float offset)
    {
        var nml = go.AddComponent<NavMeshLink>();
        nml.startPoint = new Vector3(0, -size.y / 2f, size.z / 2f + offset);
        nml.endPoint = new Vector3(0, size.y / 2f, size.z / 2f - offset);
        nml.width = size.x;

        var nml2 = go.AddComponent<NavMeshLink>();
        nml2.startPoint = new Vector3(0, -size.y / 2f, -size.z / 2f - offset);
        nml2.endPoint = new Vector3(0, size.y / 2f, -size.z / 2f + offset);
        nml2.width = size.x;

        var nml3 = go.AddComponent<NavMeshLink>();
        nml3.startPoint = new Vector3(size.x / 2f + offset, -size.y / 2f,0 );
        nml3.endPoint = new Vector3(size.x / 2f - offset, size.y / 2f,0 );
        nml3.width = size.z;

        var nml4 = go.AddComponent<NavMeshLink>();
        nml4.startPoint = new Vector3(-size.x / 2f - offset, -size.y / 2f, 0);
        nml4.endPoint = new Vector3(-size.x / 2f + offset, size.y / 2f, 0);
        nml4.width = size.z;

    }
}