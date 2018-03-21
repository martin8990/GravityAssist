
using UnityEngine;

namespace Infrastructure
{
    [RequireComponent(typeof(EnemyCombatStrategy))]

    public class EnemyAiUnit : AIUnit
    {

        EnemyCombatStrategy enemyCombat;
       
        private void Awake()
        {
           
            enemyCombat = GetComponent<EnemyCombatStrategy>();
    
            strategies.Add(enemyCombat);
        }
        
       
        

    }




}


