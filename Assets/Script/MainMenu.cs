using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void PlayGame()
    {
        if (levelLoader != null)
        {
            levelLoader.LoadNextLevel();
        }
        else
        {
            Debug.LogError("LevelLoader reference is not set in MainMenu.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
