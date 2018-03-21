//using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
//namespace Infrastructure
//{

//    public class Player : MonoBehaviour
//    {
//        public ScoreScreen scoreScreen;
//        public PlayerBudget playerScore;
//        public SimpleGun simpleGun;
//        public int HP = 100;
//        private void Awake()
//        {
//            PlayerManager.players.Add(this);
//        }
//        public void Hit(int dmg)
//        {
//            HP -= dmg;
//            if (HP == 0)
//            {
//                Die();
//            }
//        }
//        void Die()
//        {
//            AIManager.OnGameOver();
//            PlayerManager.OnGameOver();
//            scoreScreen.Open(playerScore);
//            GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);

//            GetComponent<FirstPersonController>().enabled = false;
//            Cursor.visible = true;
//            simpleGun.enabled = false;
//            this.enabled = false;

//        }
//    }




//}


