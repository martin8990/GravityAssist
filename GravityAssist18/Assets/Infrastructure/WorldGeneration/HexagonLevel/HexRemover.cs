using UnityEngine;
using Utility;
using System.Collections.Generic;
namespace Infrastructure
{
    public abstract class PlayerAction
    {
        public float Cost;
        public abstract void Execute(Player player);
    }

    public class Player : MonoBehaviour
    {
        public List<PlayerAction> toDo;
        public float ActionPoints = 100;
        private void Awake()
        {
            TurnManager.players.Add(this);
        }
        public void EndTurn()
        {
            while (toDo.Count > 0)
            { 
                var curTodo = toDo[0];
                if (ActionPoints - curTodo.Cost < 0)
                {
                    break;
                }
                else
                {
                    curTodo.Execute(this);
                    ActionPoints = -curTodo.Cost;
                }
                toDo.RemoveAt(0);
            }

        }
    }

    public class TurnManager : MonoBehaviour
    {
        public void EndTurn()
        {
            foreach (var player in MainPlayerUI.players)
            {
                player.EndTurn();
            }
        }
    }

    public class MainPlayerUI : MonoBehaviour
    {
        public static List<Player> players = new List<Player>();
        public PlayerUIMode mode;
        private void Update()
        {
            switch (mode)
            {
                case PlayerUIMode.MINE:
                    break;
                case PlayerUIMode.COMBAT:
                    break;
                default:
                    break;
            }
        }

    }
    public enum PlayerUIMode
    {
        MINE,COMBAT
    }

    public class HexRemover : MonoBehaviour
    {
        public Camera cam;
        public List<Hexagon> HexesToMine = new List<Hexagon>();

        public LayerMask HexLayer;
        Hexagon curHex;
        int miningSkill;
        public void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var hex = MousePositioning.GetTypeUnderMouse<Hexagon>(cam, HexLayer);
                if (hex != null)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        if (HexesToMine.Contains(hex))
                        {
                            HexesToMine.Remove(hex);
                        }
                    }
                    else
                    {
                        if (!HexesToMine.Contains(hex))
                        {
                            HexesToMine.Add(hex);
                        }
                    }
                }
            }
        }

        public void MineHex()
        {
            if (curHex == null && HexesToMine.Count == 0)
            {
                return;            
            }
            if (curHex == null && HexesToMine.Count > 0)
            {
                curHex = HexesToMine[0];
            }
            curHex.MiningCost -= miningSkill;
        } 

    }

}


