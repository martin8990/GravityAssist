using UnityEngine.UI;
using UnityEngine;
namespace Infrastructure
{
    public class PlayerScore : MonoBehaviour
    {
        public int Score;
        public Text scoreText;
        public SimpleGun simpleGun;
        private void Awake()
        {
            simpleGun.OnReceiveScore += AddScore;
        }

        public void AddScore(int Added)
        {
            Score += Added;
            scoreText.text = " $ : " + Score;

        }
    }

}


