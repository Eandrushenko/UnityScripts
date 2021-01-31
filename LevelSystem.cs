using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    //Level up Equation, where Y = level and X = Experience
    //y = (x + 100)x^1.5   

    private int Level;
    private float CurrentXP;
    private float XPtoNextLevel;
    private float totalXP;

    void Start()
    {
        Level = GameControl.control.Level;
        CurrentXP = GameControl.control.XP;
        XPtoNextLevel = FindXPtoNextLevel();
        totalXP = GameControl.control.totalXP;
    }

    public void AddExperience(float amount)
    {
        totalXP += amount;
        if (Level < 50)
        {
            CurrentXP += amount;
            while (CurrentXP > XPtoNextLevel)
            {
                Level++;
                CurrentXP -= XPtoNextLevel;
                XPtoNextLevel = FindXPtoNextLevel();
                GameControl.control.AP += 1;
            }
            GameControl.control.Level = Level;
            GameControl.control.XP = CurrentXP;
        }
        else if (Level > 50)
        {
            Level = 50;
            GameControl.control.Level = Level;
        }
        GameControl.control.totalXP = totalXP;
    }

    public int getLevel()
    {
        return Level;
    }

    public float getCurrentXP()
    {
        return CurrentXP;
    }

    public float getTotalXP()
    {
        return totalXP;
    }

    public float FindXPtoNextLevel()
    {
        float currentLevel;
        float NextLevel;
        currentLevel = (Level + 100) * Mathf.Pow(Level, 1.5f);
        NextLevel = ((Level+1) + 100) * Mathf.Pow((Level+1), 1.5f);
        return NextLevel - currentLevel;
    }

    public void Reset()
    {
        GameControl.control.Level = 0;
        GameControl.control.XP = 0f;
        GameControl.control.totalXP = 0f;
        GameControl.control.AP = 0;
    }

    public float GetRatio() //For the XP Bar fill on the UI
    {
        return CurrentXP / XPtoNextLevel;
    }
}
