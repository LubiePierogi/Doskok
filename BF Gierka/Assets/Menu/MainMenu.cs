using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "MainMenu", menuName = "bfg/mainmenu", order = 1)]
public class MainMenu : ScriptableObject
{
    public void PlayButton()
    {
        SceneManager.LoadScene("scene2");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
