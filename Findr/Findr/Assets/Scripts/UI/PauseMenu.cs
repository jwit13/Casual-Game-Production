using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        UIManager.isPaused = false;
    }

    public void Pause()
    {
        UIManager.menuUp = true;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        UIManager.isPaused = true;
    }

    public void PlayGame()
    {
        UIManager.menuUp = false;
        Time.timeScale = 1f;
        Paused = false;
    }

    public void BackToLobby()
    {
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene("Lobby");
    }

    public void Options()
    {
        if (Paused)
        {
            pauseMenuUI.SetActive(false);
        }

        optionsMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("quitter!");
        Application.Quit();
    }

    public void Back()
    {
        if (Paused)
        {
            pauseMenuUI.SetActive(true);
            optionsMenuUI.SetActive(false);
        }
        else
        {
            optionsMenuUI.SetActive(false);
        }
    }

    public void ToggleSound()
    {

    }

    public void ToggleMusic()
    {

    }
}
