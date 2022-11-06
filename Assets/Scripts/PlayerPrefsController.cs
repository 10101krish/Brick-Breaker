using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string LIVES_KEY = "lives";
    const string HIGHSCORE_KEY = "high score";

    public static void SetLivesCount(int livesCount)
    {
        PlayerPrefs.SetInt(LIVES_KEY, livesCount);
    }

    public static int GetLivesCount()
    {
        return PlayerPrefs.GetInt(LIVES_KEY);
    }

    public static void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, highScore);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY);
    }

}
