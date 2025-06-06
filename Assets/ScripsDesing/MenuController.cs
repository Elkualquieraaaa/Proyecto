using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
