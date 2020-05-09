using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public string levelSelect;

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
