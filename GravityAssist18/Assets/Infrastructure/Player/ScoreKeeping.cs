using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class ScoreKeeping : MonoBehaviour
    {
        public Gun gun;
        int score;
        public Text scoreTest;
        private void Start()
        {
            gun.RecieveScore += UpdateScore;
            UpdateScore(0);
        }
        public void UpdateScore(int _score)
        {
            score += _score;
            scoreTest.text = " $ " + score;

        }

    }
}





