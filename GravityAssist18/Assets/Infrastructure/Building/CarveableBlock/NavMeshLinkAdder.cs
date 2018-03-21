using System.Collections.Generic;
using UnityEngine;
using Utility;
using UnityEngine.AI;
using System.Collections;

namespace Infrastructure
{
    public class NavMeshLinkAdder : MonoBehaviour
    {
        public Vector3Int myMin
        {
            get { return (transform.position - transform.localScale / 2f).ToInt(); }
        }
        public Vector3Int myMax
        {
            get { return (transform.position + transform.localScale / 2f).ToInt(); }
        }
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
            links.Iter((x) => x.enabled = false);
        }
        public void Restore()
        {
            if (!enabled)
            {
                enabled = true;
                links.Iter((x) => x.enabled = true);
            }

        }

        public IEnumerator OnUpdate(bool source)
        {
            Debug.Log("Com");
            yield return null;
            if (enabled)
            {

                
                var scl = myMax - myMin;
               

                links.Iter((x) => Destroy(x));
                links = new List<NavMeshLink>();
                NVLAS = new HashSet<GameObject>();
                float yStart = myMax.y + 1;

                for (int x = myMin.x; x < myMax.x - 1; x++)
                {
                    var sd2 = new Vector2(x + 1f, myMin.z + 0.5f);
                    var ed2 = new Vector2(x + 1f, myMin.z - 0.5f);

                    yield return StartCoroutine(AddLinkIfAppriopriate( myMin,  myMax,  scl, yStart, sd2, ed2,source));
                }
                for (int x = myMin.x; x < myMax.x - 1; x++)
                {
                    var sd2 = new Vector2(x + 1f, myMax.z - 0.5f);
                    var ed2 = new Vector2(x + 1f, myMax.z + 0.5f);

                    yield return StartCoroutine(AddLinkIfAppriopriate( myMin,  myMax,  scl, yStart, sd2, ed2, source));
                }
                for (int z = myMin.z; z < myMax.z-1; z++)
                {
                    var sd2 = new Vector2(myMin.x + 0.5f, z+1f);
                    var ed2 = new Vector2(myMin.x - 0.5f, z+1f);

                    yield return StartCoroutine(AddLinkIfAppriopriate( myMin,  myMax,  scl, yStart, sd2, ed2, source));
                }
                for (int z = myMin.z; z < myMax.z - 1; z++)
                {
                    var sd2 = new Vector2(myMax.x - 0.5f, z + 1f);
                    var ed2 = new Vector2(myMax.x + 0.5f, z + 1f);

                    yield return StartCoroutine(AddLinkIfAppriopriate(myMin, myMax,scl, yStart, sd2, ed2, source));
                }
                
                if (source)
                {
                    yield return new WaitForSeconds(0.3f);
                    NavMeshManager.UpdateNavMesh();
                } 

            }
        }

        private IEnumerator AddLinkIfAppriopriate(Vector3Int myMin, Vector3Int myMax, Vector3Int scl, float yStart, Vector2 start, Vector2 finish,bool source)
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
                                yield return null;
                            }
                        }

                    }
                }
            }
        }
    }



}
