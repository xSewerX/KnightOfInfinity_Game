using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("StartingScreen");
    }

    public void Quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
