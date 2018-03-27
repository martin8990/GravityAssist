using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class ScoreKeeper : MonoBehaviour
    {
        
        int score;
        public Text scoreText;
        private void Start()
        {
            KeepScore(0);
        }
        public void KeepScore(int _score)
        {
            score += _score;
            scoreText.text = " $ " + score;

        }

    }
}





