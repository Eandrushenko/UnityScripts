using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text[] AbilityText;

    public void LoadAbilities()
    {
        AbilityText[0].text = PlayerPrefs.GetFloat("Health", 100).ToString();
        AbilityText[1].text = PlayerPrefs.GetInt("Heals", 5).ToString();
        AbilityText[2].text = PlayerPrefs.GetInt("ContemptShots", 0).ToString();
        AbilityText[3].text = PlayerPrefs.GetFloat("ContemptDamage", 25f).ToString();
        AbilityText[4].text = PlayerPrefs.GetFloat("Time", 0f).ToString();
        AbilityText[5].text = PlayerPrefs.GetInt("Shields", 0).ToString();
        AbilityText[6].text = PlayerPrefs.GetInt("Teleports", 0).ToString();
        AbilityText[7].text = PlayerPrefs.GetInt("CalmShots", 0).ToString();
        AbilityText[8].text = PlayerPrefs.GetFloat("CalmDamage", 5f).ToString();
        AbilityText[9].text = PlayerPrefs.GetInt("Bursts", 0).ToString();
        AbilityText[10].text = PlayerPrefs.GetFloat("Rage", 100).ToString();
        AbilityText[11].text = PlayerPrefs.GetInt("AP", 0).ToString();
    }

    public void ResetAbilities()
    {
        PlayerPrefs.SetFloat("Health", 100f);
        PlayerPrefs.SetInt("Heals", 5);
        PlayerPrefs.SetInt("ContemptShots", 0);
        PlayerPrefs.SetFloat("ContemptDamage", 25f);
        PlayerPrefs.SetFloat("Time", 0f);
        PlayerPrefs.SetInt("Shields", 0);
        PlayerPrefs.SetInt("Teleports", 0);
        PlayerPrefs.SetInt("CalmShots", 0);
        PlayerPrefs.SetFloat("CalmDamage", 5f);
        PlayerPrefs.SetInt("Bursts", 0);
        PlayerPrefs.SetFloat("Rage", 100);
        PlayerPrefs.SetInt("AP", PlayerPrefs.GetInt("Level", 0));
        LoadAbilities();
    }
}
