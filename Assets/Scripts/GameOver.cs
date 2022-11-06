using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Text messageText;
    private GameManager gameManager;

    private int currentHighScore;
    private int currentGameScore;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentHighScore = PlayerPrefsController.GetHighScore();
        ShowFinalScore();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Destroy(gameManager.gameObject);
    }

    private void ShowFinalScore()
    {
        currentGameScore = gameManager.GetFinalScore();
        scoreText.text = currentGameScore.ToString();
        if (currentHighScore < currentGameScore)
        {
            messageText.text = "New High Score !!!";
            messageText.color = Color.green;
            PlayerPrefsController.SetHighScore(currentGameScore);
        }
        else if (currentHighScore == currentGameScore)
        {
            messageText.text = "You Matched the HighScore !!!";
            messageText.color = Color.cyan;
        }
    }
}
