using System.Collections.Generic;
using UnityEngine.AI;
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
        
        AIUnit curAIUnit;
        public float SpawnInterval;
        public int amount;
        public static List<Vector3> positions = new List<Vector3>();
        public int waveCount;
        public int StartZombieHealth;
        public int DeltaZombieHealth;

        public float StartZombieSpeed;
        public float DeltaZombieSpeed;

        public void StartSpawning()
        {
            NavMeshManager.UpdateNavMesh();
            StartCoroutine(StartWave());
        }

        IEnumerator StartWave()
        {              
            for (int i = 0; i < amount; i++)
            {
                curAIUnit = Instantiate(aiPrefab);
                curAIUnit.transform.SetParent(transform, true);
                var pos = positions[Random.Range(0, positions.Count)];
                curAIUnit.transform.position = new Vector3(pos.x,0,pos.z);        
                curAIUnit.GetComponent<NavMeshAgent>().speed = StartZombieSpeed + waveCount * DeltaZombieSpeed;
                curAIUnit.GetComponent<Health>().CurrentHP = StartZombieHealth + waveCount * DeltaZombieHealth;
                AIManager.AddAI(curAIUnit);
                yield return new WaitForSeconds(SpawnInterval);
            }
            waveCount++;
            
         }
        


    }
}


