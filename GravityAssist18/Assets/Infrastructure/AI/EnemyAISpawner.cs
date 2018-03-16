using System.Collections.Generic;

using UnityEngine;
using Utility;
using UnityEngine.Events;
using System.Collections;

namespace Infrastructure
{
    public class EnemyAISpawner : MonoBehaviour
    {
        public AIUnit aiPrefab;
        public AIManager AIManager;
        
        public Vector2Int min;
        public Vector2Int max;

        AIUnit curAIUnit;
        public float SpawnInterval;

        public int amount;
        List<Vector3> positions = new List<Vector3>();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            positions.Iter((x) => Gizmos.DrawCube(x, Vector3.one));
        }

        private void Awake()
        {
            for (int x = min.x; x < max.x; x++)
            {
                positions.Add(new Vector3(x, 1, min.y));
                positions.Add(new Vector3(x, 1, max.y));
            }
            for (int z = min.y; z < max.y; z++)
            {
                positions.Add(new Vector3(min.x, 1, z));
                positions.Add(new Vector3(max.x, 1, z));
            }
        }
        private void Start()
        {
            StartCoroutine(Spawn());
        }
    
        IEnumerator Spawn()
        {
            for (int i = 0; i < amount; i++)
            {
                curAIUnit = Instantiate(aiPrefab);
                curAIUnit.transform.SetParent(transform, true);
                var spawnTFi = positions[Random.Range(0, positions.Count)];
                curAIUnit.transform.position = spawnTFi;
                AIManager.AddAI(curAIUnit);
            }
            yield return new WaitForSeconds(SpawnInterval);
            StartCoroutine(Spawn());
        }
        


    }
}


