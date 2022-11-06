using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    private GameManager gameManager;

    public Slider difficultySlider;
    int currentMaxLives;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameManager.gameObject);

        currentMaxLives = PlayerPrefsController.GetLivesCount();
        if (currentMaxLives != 0)
        {
            difficultySlider.value = currentMaxLives;
        }
        else
        {
            currentMaxLives = 3;
            difficultySlider.value = currentMaxLives;
            PlayerPrefsController.SetLivesCount(3);
        }
    }

    public void SaveAndExit()
    {
        Debug.Log(difficultySlider.value);
        currentMaxLives = ((int)difficultySlider.value);
        PlayerPrefsController.SetLivesCount(currentMaxLives);
        SceneManager.LoadScene("Main Menu");

    }
}
