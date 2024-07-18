using TMPro;
using UnityEngine;

namespace _app.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public TMP_Text scoreText;
        public int playerScore;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy((this));
            }
            else
            {
                instance = this;
            }
        }

        public void ChangeScore(int scoreAmount)
        {
            playerScore += scoreAmount;
            scoreText.text = "Player Score: " + playerScore.ToString();
        }

        
    }
    
    
}