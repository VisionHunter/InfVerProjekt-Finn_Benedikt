using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI; // keine Ahnung
    public GameObject pauseScreenUI;
    private bool istGameOver;
    public bool isPaused;
    public TextMeshProUGUI counterText;
    int kills = 0;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !istGameOver)
        {
            if(isPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }

        ShowKills();
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        istGameOver = true;
    }

    public void Pause()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true; 
    }
    
    public void Continue()
    {
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void ShowKills()
    {
        counterText.text = kills.ToString();
    }

    public void AddKillCount()
    {
        kills++;
    }
}