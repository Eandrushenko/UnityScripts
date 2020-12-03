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
        Level = PlayerPrefs.GetInt("Level", 0);
        CurrentXP = PlayerPrefs.GetFloat("XP", 0f);
        XPtoNextLevel = FindXPtoNextLevel();
        totalXP = PlayerPrefs.GetFloat("totalXP", 0f);
    }

    public void AddExperience(float amount)
    {
        totalXP += amount;
        CurrentXP += amount;
        while (CurrentXP > XPtoNextLevel)
        {
            Level++;
            CurrentXP -= XPtoNextLevel;
            XPtoNextLevel = FindXPtoNextLevel();
            PlayerPrefs.SetInt("AP", (PlayerPrefs.GetInt("AP", 0) + 1));
        }
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetFloat("XP", CurrentXP);
        PlayerPrefs.SetFloat("totalXP", totalXP);
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
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetFloat("XP", 0f);
        PlayerPrefs.SetFloat("totalXP", 0f);
        PlayerPrefs.SetInt("AP", 0);
    }

    public float GetRatio() //For the XP Bar fill on the UI
    {
        return CurrentXP / XPtoNextLevel;
    }
}
