using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Utility;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

namespace Infrastructure
{

    public class EnemyAISpawner : MonoBehaviour
    {
        public AIUnit aiPrefab;
        public AIManager AIManager;

        AIUnit curAIUnit;
        public float SpawnInterval;
        public int amount;

        public int waveCount;
        public int StartZombieHealth;
        public int DeltaZombieHealth;

        public float StartZombieSpeed;
        public float DeltaZombieSpeed;

        public bool repeat = true;
        public Text RoundText;
        public bool startSpawning;
        private void Start()
        {
            if (startSpawning)
            {
                StartSpawning();
            }
        }

        public void StartSpawning()
        {
            NavMeshManager.UpdateNavMesh();
            StartCoroutine(StartWave());
        }

        IEnumerator StartWave()
        {
            RoundText.text = "Round : " + waveCount;
            yield return new WaitForSeconds(2f);

            for (int i = 0; i < amount; i++)
            {
                curAIUnit = Instantiate(aiPrefab);

                curAIUnit.transform.SetParent(transform, true);

                var pos = HexagonLevelGenerator.SpawnPositions[Random.Range(0, HexagonLevelGenerator.SpawnPositions.Count)];

                curAIUnit.transform.position = new Vector3(pos.x, -1f, pos.z);
                curAIUnit.GetComponent<NavMeshAgent>().enabled = false;
                curAIUnit.GetComponent<NavMeshAgent>().enabled = true;

                curAIUnit.GetComponent<NavMeshAgent>().speed = StartZombieSpeed + waveCount * DeltaZombieSpeed;
                curAIUnit.GetComponent<Health>().CurrentHP = StartZombieHealth + waveCount * DeltaZombieHealth;

                AIManager.AddAI(curAIUnit);
                yield return new WaitForSeconds(SpawnInterval);
            }
            waveCount++;
            if (repeat)
            {
                StartCoroutine(StartWave());
            }

        }



    }
}


