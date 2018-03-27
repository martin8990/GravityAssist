using System.Collections;
using UnityEngine;
using UnityEngine.AI;
namespace Infrastructure
{
    public class EnemySpawnTactic : Tactic
    {
        public int SpawnFrames = 300;
        public float SpawnOffset = 2;
        int frame = 0;
        float t = 0;
        public ParticleSystem spawnParticlesPF;
        ParticleSystem ps;
        public override float CalculateUtility()
        {
            return 1f;
        }
        public void Update()
        {
            t += Time.deltaTime;
            if (t > frame * 0.016f)
            {
                
                if (frame == 0)
                {
                    GetComponent<NavMeshAgent>().enabled = false;
                    var p = transform.position;
                    transform.position = new Vector3(p.x, p.y - SpawnOffset, p.z);
                    frame++;
                    ps = Instantiate(spawnParticlesPF);
                    ps.transform.position = new Vector3(p.x, 0, p.z);
                }
                if (frame < SpawnFrames)
                {
                    var p = transform.position;
                    transform.position = new Vector3(p.x, p.y + SpawnOffset / SpawnFrames, p.z);
                    frame++;
                }
                else
                {
                    GetComponent<NavMeshAgent>().enabled = true;
                    GetComponent<EnemySpawnStrategy>().hasSpawned = true;
                    enabled = false;
                    frame = 0;
                    Destroy(ps.gameObject);
                }
            }
            

        }

        public override IEnumerator Execute(int Period)
        {
            enabled = true;
            yield return null;
        }
    }


}


