using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text playerScoreText;
    public Text opponentScoreText;
    public Text WinnerText;

    private int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        playerScoreText.text = PlayerPrefs.GetInt("playerScore") + "";
        opponentScoreText.text = PlayerPrefs.GetInt("opponentScore") + "";

        ShowWinner();
    }

    // Shows the player with higher score as winner
    void ShowWinner()
    {
        if (PlayerPrefs.GetInt("playerScore") > PlayerPrefs.GetInt("opponentScore"))
        {
            WinnerText.text = "Winner: Player 1";
        }
        else
        {
            WinnerText.text = "Winner: Player 2";
        }
    }
   
    // Loads the next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Exits the application
    public void QuitGame()
    {
        Application.Quit();
    }

    // Loads the first scene
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    // Set difficulty easy (0 - easy) 
    public void SetDifficultyEasy()
    {
        difficulty = 0;
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    // Set difficulty medium (1 - medium)
    public void SetDifficultyMedium()
    {
        difficulty = 1;
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    // Set difficulty hard (2 - hard)
    public void SetDifficultyHard()
    {
        difficulty = 2;
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }
}
