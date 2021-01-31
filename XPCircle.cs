using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPCircle : MonoBehaviour {

    public Text CurXP;
    public Text NextXP;
    public Text TotalXP;

    private int Level;
    private float currentXP;
    private float totalXP;

    public Image CircleFill;
    public Text CurLevel;
    public Text NextLevel;

    public void DisplayStats()
    {
        GameControl.control.LoadInfo();


        if (GameControl.control.Level < 50)
        {
            Level = GameControl.control.Level;
            currentXP = GameControl.control.XP;
            CircleFill.fillAmount = GetRatio();
            CurXP.text = Mathf.FloorToInt(currentXP).ToString();
            NextXP.text = Mathf.FloorToInt(FindXPtoNextLevel()).ToString();
            CurLevel.text = Level.ToString();
            NextLevel.text = (Level + 1).ToString();
        }
        else
        {
            Level = 50;
            //currentXP = GameControl.control.XP;
            CircleFill.fillAmount = 1;
            CurXP.text = "MAX";
            NextXP.text = "MAX";
            CurLevel.text = Level.ToString();
            NextLevel.text = "MAX";
        }

        totalXP = GameControl.control.totalXP;
        TotalXP.text = Mathf.FloorToInt(totalXP).ToString();

        GameControl.control.MM = 1;
    }

    public float FindXPtoNextLevel()
    {
        float currentLevel;
        float NextLevel;
        currentLevel = (Level + 100) * Mathf.Pow(Level, 1.5f);
        NextLevel = ((Level + 1) + 100) * Mathf.Pow((Level + 1), 1.5f);
        return NextLevel - currentLevel;
    }

    public float GetRatio() //For the XP Bar fill on the UI
    {
        return currentXP / FindXPtoNextLevel();
    }
}
