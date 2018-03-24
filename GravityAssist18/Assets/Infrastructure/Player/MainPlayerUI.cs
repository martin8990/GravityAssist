using UnityEngine;
using System.Collections.Generic;
namespace Infrastructure
{

    public class MainPlayerUI : MonoBehaviour
    {
        public static List<Player> players = new List<Player>();
        Player currentPlayer;
        public PlayerUIMode mode = PlayerUIMode.MENU;
        public GameObject RTScanvas;
        public GameObject FPScanvas;
        public GameObject RTSController;
        public GameObject FPSController;

        private void Start()
        {
            FPSController.SetActive(false);
        }

        private void Update()
        {
            if (players.Count > 0)
            {
                currentPlayer = players[0];
                switch (mode)
                {
                    case PlayerUIMode.MENU:
                        break;
                    case PlayerUIMode.MINE:
                        currentPlayer.miningModule.SelectHexes(currentPlayer);
                        break;
                    case PlayerUIMode.COMBAT:
                        break;
                    default:
                        break;


                }
                if (Input.GetMouseButtonDown(1))
                {
                    currentPlayer.miningModule.ResetCol();
                    mode = PlayerUIMode.MENU;
                }
               

            }
        }
        public void SetMineMode()
        {
            mode = PlayerUIMode.MINE;
        }

        public void GoToFPS()
        {
            RTScanvas.SetActive(false);
            RTSController.SetActive(false);

            FPScanvas.SetActive(true);
            FPSController.SetActive(true);
            FPSController.transform.position = EnemyAISpawner.positions[0];
        }

    }

    public enum PlayerUIMode
    {
        MINE,COMBAT,
        MENU
    }

}


