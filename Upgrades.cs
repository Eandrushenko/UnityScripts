using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text[] AbilityText;

    public void LoadAbilities()
    {
        AbilityText[0].text = GameControl.control.Health.ToString();
        AbilityText[1].text = GameControl.control.Heals.ToString();
        AbilityText[2].text = GameControl.control.ContemptShots.ToString();
        AbilityText[3].text = GameControl.control.ContemptDamage.ToString();
        AbilityText[4].text = GameControl.control.Time.ToString();
        AbilityText[5].text = GameControl.control.Shields.ToString();
        AbilityText[6].text = GameControl.control.Teleports.ToString();
        AbilityText[7].text = GameControl.control.CalmShots.ToString();
        AbilityText[8].text = GameControl.control.CalmDamage.ToString();
        AbilityText[9].text = GameControl.control.Bursts.ToString();
        AbilityText[10].text = GameControl.control.Rage.ToString();
        AbilityText[11].text = GameControl.control.AP.ToString();
    }

    public void ResetAbilities()
    {
        GameControl.control.Health = 100f;
        GameControl.control.Heals = 3;
        GameControl.control.ContemptShots = 0;
        GameControl.control.ContemptDamage = 25f;
        GameControl.control.Time = 0f;
        GameControl.control.Shields = 0;
        GameControl.control.Teleports = 0;
        GameControl.control.CalmShots = 0;
        GameControl.control.CalmDamage = 6f;
        GameControl.control.Bursts = 0;
        GameControl.control.Rage = 100f;
        GameControl.control.AP = GameControl.control.Level;
        LoadAbilities();
    }
}
