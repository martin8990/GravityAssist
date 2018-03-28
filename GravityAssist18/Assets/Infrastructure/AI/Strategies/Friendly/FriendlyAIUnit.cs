
//using UnityEngine;
//using System.Collections.Generic;
//namespace Infrastructure
//{

//    [RequireComponent(typeof(DebugStrategy))]
//    [RequireComponent(typeof(FriendlyCombatStrategy))]
//    public class FriendlyAIUnit : AIUnit
//    {

//        DebugStrategy debugStrategy;
//        [HideInInspector]
//        public FriendlyCombatStrategy combatStrategy;

//        public Queue<Order> orders = new Queue<Order>();
//        Order currentOrder;
//        private void Awake()
//        {
//            combatStrategy = GetComponent<FriendlyCombatStrategy>();
//            debugStrategy = GetComponent<DebugStrategy>();
//            strategies.Add(debugStrategy);
//            strategies.Add(combatStrategy);
//        }
//        public override void Trigger(int period)
//        {
//            if (currentOrder != null)
//            {
//                currentOrder.Execute(period);
//            }
//            else if (orders.Count > 0)
//            {
//                currentOrder = orders.Dequeue();
//                currentOrder.Execute(period);
//            }
//            else
//            {
//                base.Trigger(period);
//            }
//        }

//    }

//}


