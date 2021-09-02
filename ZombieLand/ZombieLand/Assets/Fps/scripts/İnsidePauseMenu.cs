using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class İnsidePauseMenu : MonoBehaviour
{

    public GameObject PauseMenuHolder;
    public GameObject OptionsHolder;
    public GameObject HelpHolder;
    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Settings()
    {
        OptionsHolder.SetActive(true);
    }
    public void SettingsMenu()
    {
        OptionsHolder.SetActive(false);  
    }
    public void Help()
    {
        HelpHolder.SetActive(true);
    }
    public void BackHelp()
    {
        HelpHolder.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
