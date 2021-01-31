using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int Level;
    public float XP;
    public float totalXP;
    public float Health;
    public int Heals;
    public int ContemptShots;
    public float ContemptDamage;
    public float Time;
    public int Shields;
    public int Teleports;
    public int CalmShots;
    public float CalmDamage;
    public int Bursts;
    public float Rage;
    public int AP; //Ability Points
    public int LP; //Level Progress
    public int Cursor;

    public int MM = 0; //Main Menu control variable

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
	}

    void Start()
    {
        LoadInfo();
    }

    public void LoadInfo()
    {
        control.Level = PlayerPrefs.GetInt("Level", 0);
        control.XP = PlayerPrefs.GetFloat("XP", 0f);
        control.totalXP = PlayerPrefs.GetFloat("totalXP", 0f);
        control.Health = PlayerPrefs.GetFloat("Health", 100);
        control.Heals = PlayerPrefs.GetInt("Heals", 3);
        control.ContemptShots = PlayerPrefs.GetInt("ContemptShots", 0);
        control.ContemptDamage = PlayerPrefs.GetFloat("ContemptDamage", 25f);
        control.Time = PlayerPrefs.GetFloat("Time", 0f);
        control.Shields = PlayerPrefs.GetInt("Shields", 0);
        control.Teleports = PlayerPrefs.GetInt("Teleports", 0);
        control.CalmShots = PlayerPrefs.GetInt("CalmShots", 0);
        control.CalmDamage = PlayerPrefs.GetFloat("CalmDamage", 6f);
        control.Bursts = PlayerPrefs.GetInt("Bursts", 0);
        control.Rage = PlayerPrefs.GetFloat("Rage", 100f);
        control.AP = PlayerPrefs.GetInt("AP", 0);
        control.LP = PlayerPrefs.GetInt("LP", 1);
        control.Cursor = PlayerPrefs.GetInt("Cursor", 0);
    }

    public void SaveInfo()
    {
        PlayerPrefs.SetInt("Level", control.Level);
        PlayerPrefs.SetFloat("XP", control.XP);
        PlayerPrefs.SetFloat("totalXP", control.totalXP);
        PlayerPrefs.SetFloat("Health", control.Health);
        PlayerPrefs.SetInt("Heals", control.Heals);
        PlayerPrefs.SetInt("ContemptShots", control.ContemptShots);
        PlayerPrefs.SetFloat("ContemptDamage", control.ContemptDamage);
        PlayerPrefs.SetFloat("Time", control.Time);
        PlayerPrefs.SetInt("Shields", control.Shields);
        PlayerPrefs.SetInt("Teleports", control.Teleports);
        PlayerPrefs.SetInt("CalmShots", control.CalmShots);
        PlayerPrefs.SetFloat("CalmDamage", control.CalmDamage);
        PlayerPrefs.SetInt("Bursts", control.Bursts);
        PlayerPrefs.SetFloat("Rage", control.Rage);
        PlayerPrefs.SetInt("AP", control.AP);
        PlayerPrefs.SetInt("LP", control.LP);
        PlayerPrefs.SetInt("Cursor", control.Cursor);
        PlayerPrefs.Save();
    }

    public void ResetInfo()
    {
        control.Level = 0;
        control.XP = 0f;
        control.Health = 100;
        control.Heals = 3;
        control.ContemptShots = 0;
        control.ContemptDamage = 25f;
        control.Time = 0f;
        control.Shields = 0;
        control.Teleports = 0;
        control.CalmShots = 0;
        control.CalmDamage = 6f;
        control.Bursts = 0;
        control.Rage = 100f;
        control.AP = 0;
        control.LP = 1;
        control.Cursor = 0;
        control.MM = 0;
    }
}
