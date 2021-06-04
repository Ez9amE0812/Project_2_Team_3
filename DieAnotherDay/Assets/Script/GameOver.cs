using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOver;
    public GameObject scoreBoard;
    public AudioSource music;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.died)
        {
            gameOver.SetActive(true);
            scoreBoard.SetActive(false);
            music.Stop();
            scoreText.text = "Your Score: " + Score.playerScore.ToString();
            int highScore = PlayerPrefs.GetInt("highscore", 0);
            highscoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
