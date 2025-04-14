using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public AudioSource gameOverMusic;
    void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        if (gameOverMusic != null)
        {
            gameOverMusic.Play();
        }
    }
    public void Yes()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void No()
    {
        SceneManager.LoadScene(0);
    }

}
