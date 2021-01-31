using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overseer : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject PauseMenu;
    public Animator transiton;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            FindObjectOfType<AudioManager>().Play("PopUp");
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
        FindObjectOfType<AudioManager>().Play("Click");
        isPaused = false;
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        isPaused = false;
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {

        transiton.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Menu");
    }

    public void DeathQuit()
    {
        StartCoroutine(DQ());
    }

    IEnumerator DQ()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(LoadLevel());
    }
}
