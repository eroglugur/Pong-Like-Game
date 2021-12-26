using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private GameManager gameManager;

    // Access to the ball 
    public GameObject ball;

    // Scores
    private int playerScore;
    private int opponentScore;

    // UI
    public Text opponentScoreText;
    public Text playerScoreText;

    // Sound effects
    public AudioSource scoreSound;

    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("playerScore", 0);
        PlayerPrefs.SetInt("opponentScore", 0);

        playerScore = 0;
        opponentScore = 0;

        opponentScoreText.text = opponentScore + "";
        playerScoreText.text = playerScore + "";
    }

    void Update()
    {
        if (playerScore == 10 || opponentScore == 10)
        {
            StartCoroutine("FinishGame");
        }    
    }

    // Loads the finish screen after waiting 0.75 seconds
    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(0.75f);
        gameManager = FindObjectOfType<GameManager>();
        gameManager.LoadNextScene();
    }


    // Increases the opponents's score, plays score sound
    public void UpdateOpponentScore()
    {
        scoreSound.Play();
        opponentScore++;
        PlayerPrefs.SetInt("opponentScore", opponentScore);
        opponentScoreText.text = opponentScore + "";
    }

    // Increases the player's score, plays score sound
    public void UpdatePlayerScore()
    {
        scoreSound.Play();
        playerScore++;
        PlayerPrefs.SetInt("playerScore", playerScore);
        playerScoreText.text = playerScore + "";
    }

}
