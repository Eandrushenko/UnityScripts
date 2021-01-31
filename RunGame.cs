using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunGame : MonoBehaviour {

    public void BeginPlay()
    {
        StartScript game = GetComponent<StartScript>();
        game.startGame();
    }

    public void ResetPlay()
    {
        SceneManager.LoadScene("Start");
    }
}
