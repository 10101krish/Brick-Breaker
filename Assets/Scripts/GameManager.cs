using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;

    public Ball ball;
    public Paddle paddle;
    public Brick[] bricks;
    public int bricksCount;

    private int currentSceneIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
        bricksCount = bricks.Length;
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        lives = PlayerPrefsController.GetLivesCount();
        score = 0;
    }

    public void Miss()
    {
        lives--;
        if (lives > 0) ResetLevel();
        else GameOver();
    }

    private void ResetLevel()
    {
        paddle.Reset();
        ball.Reset();
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void AddToScore(int value)
    {
        score += value;
    }

    public void BrickDestroyed()
    {
        bricksCount--;
        if (bricksCount == 0) LoadNextScene();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        currentSceneIndex++;
        return;
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public int GetFinalScore()
    {
        return score;
    }
}
