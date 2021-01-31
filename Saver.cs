using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour {


    //Class must exist due to SaveInfo not being correctly called when referencing Gamecontrol object directly in the onclick function
    //Possibly because it might not be using the public static control variable when, but this function guartees that it will.

    public void SaveGame()
    {
        GameControl.control.SaveInfo();
    }

    public void ResetGame()
    {
        GameControl.control.ResetInfo();
    }
}
