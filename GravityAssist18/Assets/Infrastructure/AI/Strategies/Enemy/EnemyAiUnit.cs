
using UnityEngine;

namespace Infrastructure
{
    [RequireComponent(typeof(EnemyCombatStrategy))]
    [RequireComponent(typeof(EnemySpawnStrategy))]
    public class EnemyAiUnit : AIUnit
    {

        EnemyCombatStrategy enemyCombat;
        EnemySpawnStrategy spawn;
        private void Awake()
        {
                
            enemyCombat = GetComponent<EnemyCombatStrategy>();
            spawn = GetComponent<EnemySpawnStrategy>();
            strategies.Add(enemyCombat);
            strategies.Add(spawn);
        }
        
       
        

    }




}


