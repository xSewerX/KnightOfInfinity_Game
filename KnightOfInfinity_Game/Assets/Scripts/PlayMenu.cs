using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level3");
    }

    public void ChangeLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartingScreen");
    }

    public void Quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
