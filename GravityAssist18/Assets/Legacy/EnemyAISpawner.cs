//using System.Collections.Generic;
//using UnityEngine.AI;
//using UnityEngine;
//using Utility;
//using UnityEngine.Events;
//using System.Collections;

//namespace Infrastructure
//{

//    public class EnemyAISpawner : MonoBehaviour
//    {
//        public AIUnit aiPrefab;
//        public AIManager AIManager;
        
//        AIUnit curAIUnit;
//        public float SpawnInterval;
//        public int amount;
//        public List<Transform> positions = new List<Transform>();
//        public int waveCount;
//        public int StartZombieHealth;
//        public int DeltaZombieHealth;

//        public float StartZombieSpeed;
//        public float DeltaZombieSpeed;

//        private void OnDrawGizmos()
//        {
//            Gizmos.color = Color.green;
//            positions.Iter((x) => Gizmos.DrawCube(x, Vector3.one));
//        }

//        private void Start()
//        {
//            var hm = heightMap.heightMap;
//            var maxX = hm.GetLength(0)-1;
//            var maxZ = hm.GetLength(1)-1;

//            for (int x = 0; x <= maxX; x++)
//            {
//                positions.Add(new Vector3(x, hm[x,0], 0));
//                positions.Add(new Vector3(x, hm[x,maxZ],maxZ));
//            }
//            for (int z = 0; z <= maxZ; z++)
//            {
//                positions.Add(new Vector3(0, hm[0,z], z));
//                positions.Add(new Vector3(maxX, hm[maxX, z], z));
//            }
//        }
//        public void StartWave()
//        {              
//            for (int i = 0; i < amount; i++)
//            {
//                curAIUnit = Instantiate(aiPrefab);
//                curAIUnit.transform.SetParent(transform, true);
//                var spawnTFi = positions[Random.Range(0, positions.Count)];
//                curAIUnit.transform.position = spawnTFi;
//                curAIUnit.GetComponent<NavMeshAgent>().speed = StartZombieSpeed + waveCount * DeltaZombieSpeed;
//                curAIUnit.GetComponent<Health>().CurrentHP = StartZombieHealth + waveCount * DeltaZombieHealth;
//                AIManager.AddAI(curAIUnit);
//            }
//            waveCount++;
            
//         }
        


//    }
//}


