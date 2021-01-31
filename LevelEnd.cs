using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {

    public int progress;

    public Animator transiton;

    public Image image;

    public Sprite happy;

    void OnTriggerEnter2D(Collider2D col)
    {
        image.sprite = happy;
        Player player = col.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (progress > GameControl.control.LP)
            {
                GameControl.control.LP = progress;
            }
            GameControl.control.SaveInfo();
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transiton.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Menu");
    }

    public void BackMenu()
    {
        image.sprite = happy;
        if (progress > GameControl.control.LP)
        {
            GameControl.control.LP = progress;
        }
        GameControl.control.SaveInfo();
        StartCoroutine(LoadLevel());
    }
}
