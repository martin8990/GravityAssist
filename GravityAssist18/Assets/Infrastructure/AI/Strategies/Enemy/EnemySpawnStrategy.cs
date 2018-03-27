using UnityEngine;
namespace Infrastructure
{
    [RequireComponent(typeof(EnemySpawnTactic))]
    public class EnemySpawnStrategy : Strategy
    {
        
        private void Awake()
        {
            var enemySpawnTactic = GetComponent<EnemySpawnTactic>();
            tactics.Add(enemySpawnTactic);
        }
        public bool hasSpawned;
        public override float GetStrategyUtility()
        {
            if (!hasSpawned)
            {
                return 1f;
            }
            else
            {
                return 0;
            }
        }
    }


}


