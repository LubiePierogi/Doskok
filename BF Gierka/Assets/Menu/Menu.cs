using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Menu", menuName = "bfg/menu", order = 1)]
public class Menu : ScriptableObject
{
    int numberOfLevels = 5;
    public int levelNumber = 0;
    public void PlayButton()
    {
        LoadLevel(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void LoadLevel(int l)
    {
        levelNumber = l;
        if (l > numberOfLevels)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            SceneManager.LoadScene("Level" + l);
        }
    }
    public void NextLevel()
    {
        LoadLevel(levelNumber + 1);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
