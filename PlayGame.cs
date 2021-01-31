using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

    public Animator transiton;

    public string AreaSelect;

    public void PlayNextLevel()
    {
        string area = "Area" + GameControl.control.LP.ToString();
        StartCoroutine(LoadLevel(area));
    }

    public void PlaySelectedLevel()
    {
        StartCoroutine(LoadLevel(AreaSelect));
    }

    IEnumerator LoadLevel(string Area)
    {
        transiton.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(Area);
    }
}
