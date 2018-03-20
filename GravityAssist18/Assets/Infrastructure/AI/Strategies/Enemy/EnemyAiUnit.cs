
using UnityEngine;

namespace Infrastructure
{
    [RequireComponent(typeof(EnemyCombatStrategy))]
    [RequireComponent(typeof(DebugStrategy))]
    [RequireComponent(typeof(Health))]
    public class EnemyAiUnit : AIUnit
    {

        EnemyCombatStrategy enemyCombat;
        DebugStrategy debugStrategy;
        Health health;
        private void Awake()
        {
            debugStrategy = GetComponent<DebugStrategy>();
            enemyCombat = GetComponent<EnemyCombatStrategy>();
            health = GetComponent<Health>();
            strategies.Add(enemyCombat);
            strategies.Add(debugStrategy);
        }
        private void Start()
        {
            health.OnDeath += () => AIManager.AIUnits.Remove(this);
            health.OnDeath += () => Destroy(gameObject);
        }
        

    }




}


