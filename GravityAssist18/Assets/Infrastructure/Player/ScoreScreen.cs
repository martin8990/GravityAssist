using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Infrastructure
{
    public class ScoreScreen : MonoBehaviour
    {
        public GameObject ScoreScreenGO;
        public Button tryAgainButton;
        public Text FinalScore;
        public void Awake()
        {

        }
        public void Open(PlayerScore playerScore)
        {
            
            ScoreScreenGO.SetActive(true);
            FinalScore.text = "Your final Score was : " + playerScore.Score;
       //     tryAgainButton.onClick.AddListener(OnTryAgain);
        }
        public void OnTryAgain()
        {
            Debug.Log("yo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }




}


