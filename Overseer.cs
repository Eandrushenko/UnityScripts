using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overseer : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject PauseMenu;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            PauseMenu.SetActive(isPaused);
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenu.SetActive(isPaused);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
