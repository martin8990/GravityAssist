using System.Collections.Generic;

using UnityEngine;
using Utility;
using UnityEngine.Events;
namespace Infrastructure
{
    public class EnemyAISpawner : MonoBehaviour
    {
        public AIUnit aiPrefab;
        public AIManager AIManager;
        AIUnit curAIUnit;
        Camera cam;


        public int amount;
        public List<Transform> positions;

        private void Awake()
        {
            cam = Camera.main;
        }

        public void OnSpawn()
        {
            for (int i = 0; i < amount; i++)
            {
                curAIUnit = Instantiate(aiPrefab);
                curAIUnit.transform.SetParent(transform, true);
                var spawnTFi = positions[Random.Range(0, positions.Count)];
                curAIUnit.transform.position = spawnTFi.position;
                AIManager.AddAI(curAIUnit);
            }
        }
        


    }
}


