using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;

    private bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    // Freezes time, activates pause screen
    void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
        gamePaused = true;
    }

    // Unfreezes time, disactivates pause screen
    void Resume()
    {
        pauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
}
