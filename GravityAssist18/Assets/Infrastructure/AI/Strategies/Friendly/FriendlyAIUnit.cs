
using UnityEngine;

namespace Infrastructure
{ 
    [RequireComponent(typeof(FollowOrders))]
    [RequireComponent(typeof(DebugStrategy))]
    public class FriendlyAIUnit : AIUnit
    {
        Health health;
        DebugStrategy debugStrategy;
        FollowOrders follow;
        private void Awake()
        {
            follow = GetComponent<FollowOrders>();
            debugStrategy = GetComponent<DebugStrategy>();
            strategies.Add(debugStrategy);
            strategies.Add(follow);
        }

    }




}


