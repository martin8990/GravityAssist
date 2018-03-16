
using UnityEngine;

namespace Infrastructure
{
    [RequireComponent(typeof(SimpleCombat))]
    [RequireComponent(typeof(Health))]
    public class EnemyAiUnit : AIUnit
    {

        SimpleCombat simpleCombat;
        Health health;
        private void Awake()
        {
            simpleCombat = GetComponent<SimpleCombat>();
            health = GetComponent<Health>();
            strategies.Add(simpleCombat);
        }
        private void Start()
        {
            health.OnDeath += OnRemove;
            health.OnDeath += () => Destroy(gameObject);

        }

    }




}


