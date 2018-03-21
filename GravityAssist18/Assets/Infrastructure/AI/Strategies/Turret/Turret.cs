
using UnityEngine;
using System.Collections.Generic;
namespace Infrastructure
{

    [RequireComponent(typeof(DebugStrategy))]
    [RequireComponent(typeof(TurretCombatStrategy))]
    public class Turret : AIUnit
    {

        DebugStrategy debugStrategy;
        [HideInInspector]
        public TurretCombatStrategy combatStrategy;
        private void Awake()
        {
            combatStrategy = GetComponent<TurretCombatStrategy>();
            debugStrategy = GetComponent<DebugStrategy>();
            strategies.Add(debugStrategy);
            strategies.Add(combatStrategy);
        }
    

    }

}


