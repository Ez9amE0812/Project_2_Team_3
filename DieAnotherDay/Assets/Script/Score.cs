using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public static int playerScore;
    private int highScore;
    void Start()
    {
        playerScore = 0;
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Your Score: " + playerScore.ToString();
        highscoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Your Score: " + playerScore.ToString();
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highscore", playerScore);
        }
            
        highscoreText.text = "High Score: " + highScore.ToString();
        
    }
}
