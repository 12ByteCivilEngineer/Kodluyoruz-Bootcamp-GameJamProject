using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Ingame : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject inGameScreen;

   
    public void PauseScreen()
    {
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        GameManager.isGameRunning = false;
    }
    public void InGameScreen()
    {
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
        Time.timeScale = 1f;
        GameManager.isGameRunning = true;

    }

    public void BackMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
