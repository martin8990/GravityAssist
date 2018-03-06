using System.Collections.Generic;
using UnityEngine;
using Utility;
using UnityEngine.AI;
using System.Collections;

namespace Infrastructure
{
    public class NavMeshLinkAdder : MonoBehaviour
    {
        public List<NavMeshLink> links = new List<NavMeshLink>();
        public LayerMask mask;
        public CarvableBlock carvableBlock;
        public int LinkAdderLayer = 16;
        HashSet<GameObject> NVLAS;


        private void Start()
        {
            carvableBlock.Commit += () => StartCoroutine(OnUpdate(true));
            carvableBlock.Disable += Disable;
            carvableBlock.Restore += Restore;
        }        
            
        public void Disable()
        {
            enabled = false;
            links.Iter((x) => Destroy(x));
            links = new List<NavMeshLink>();
        }
        public void Restore()
        {
            enabled = true;
        }

        public IEnumerator OnUpdate(bool source)
        {
            yield return null;
            if (enabled)
            {

                Vector3Int myMin = carvableBlock.carveMaster.myMin;
                Vector3Int myMax = carvableBlock.carveMaster.myMax;
                var scl = myMax - myMin;
               

                links.Iter((x) => Destroy(x));
                links = new List<NavMeshLink>();
                NVLAS = new HashSet<GameObject>();
                float yStart = myMax.y + 1;

                for (int x = myMin.x; x < myMax.x - 1; x++)
                {
                    var sd2 = new Vector2(x + 1f, myMin.z + 0.5f);
                    var ed2 = new Vector2(x + 1f, myMin.z - 0.5f);

                    AddLinkIfAppriopriate(ref myMin, ref myMax, ref scl, yStart, sd2, ed2,source);
                }
                for (int x = myMin.x; x < myMax.x - 1; x++)
                {
                    var sd2 = new Vector2(x + 1f, myMax.z - 0.5f);
                    var ed2 = new Vector2(x + 1f, myMax.z + 0.5f);

                    AddLinkIfAppriopriate(ref myMin, ref myMax, ref scl, yStart, sd2, ed2, source);
                }
                for (int z = myMin.z; z < myMax.z-1; z++)
                {
                    var sd2 = new Vector2(myMin.x + 0.5f, z+1f);
                    var ed2 = new Vector2(myMin.x - 0.5f, z+1f);

                    AddLinkIfAppriopriate(ref myMin, ref myMax, ref scl, yStart, sd2, ed2, source);
                }
                for (int z = myMin.z; z < myMax.z - 1; z++)
                {
                    var sd2 = new Vector2(myMax.x - 0.5f, z + 1f);
                    var ed2 = new Vector2(myMax.x + 0.5f, z + 1f);

                    AddLinkIfAppriopriate(ref myMin, ref myMax, ref scl, yStart, sd2, ed2, source);
                }
                NavMeshManager.UpdateNavMesh();

            }
        }

        private void AddLinkIfAppriopriate(ref Vector3Int myMin, ref Vector3Int myMax, ref Vector3Int scl, float yStart, Vector2 start, Vector2 finish,bool source)
        {
            RaycastHit startHit;
            RaycastHit endHit;
            if (Physics.Raycast(new Vector3(start.x, yStart, start.y), Vector3.down, out startHit, 100, mask))
            {
                 
                //Debug.Log("height " +  myMax.y);
                //Debug.Log("hit " + (int)startHit.point.y);
        
                if (Mathf.CeilToInt(startHit.point.y) == myMax.y)
                {                   
                    if (Physics.Raycast(new Vector3(finish.x, yStart, finish.y), Vector3.down, out endHit, 100, mask))
                    {
                        var otherGo = endHit.collider.gameObject;
                        if (Mathf.CeilToInt(endHit.point.y) < myMin.y + scl.y)
                        {
                            
                            var link = gameObject.AddComponent<NavMeshLink>();
                            link.startPoint = startHit.point - transform.position;
                            link.endPoint = endHit.point - transform.position;
                            link.width = 1;
                            links.Add(link);

                        }
                        else if (source && otherGo.layer == 15)
                        {
                            if (!NVLAS.Contains(otherGo))
                            {
                                Debug.Log("Update Other " + otherGo.name);
                                StartCoroutine(otherGo.GetComponentInChildren<NavMeshLinkAdder>().OnUpdate(false));
                                NVLAS.Add(otherGo);
                            }
                        }

                    }
                }
            }
        }
    }



}
