using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPoints : MonoBehaviour
{
    //TODO: Add a cap for upgrades
    public Text AbilityText;
    public Text APText;

    private bool SpendPoints()
    {
        bool hasPoints = false;
        if (GameControl.control.AP > 0)
        {
            hasPoints = true;
            GameControl.control.AP -= 1;
            APText.text = GameControl.control.AP.ToString();
        }
        return hasPoints;
    }

    public void upgradeHealth()
    {
        if (SpendPoints())
        {
            GameControl.control.Health += 100f;
            AbilityText.text = GameControl.control.Health.ToString();
        }
    }

    public void upgradeHeals()
    {
        if (SpendPoints())
        {
            GameControl.control.Heals += 1;
            AbilityText.text = GameControl.control.Heals.ToString();
        }
    }

    public void upgradeContemptShots()
    {
        if (SpendPoints())
        {
            GameControl.control.ContemptShots += 10;
            AbilityText.text = GameControl.control.ContemptShots.ToString();
        }
    }

    public void upgradeContemptDamage()
    {
        if (SpendPoints())
        {
            GameControl.control.ContemptDamage += 15f;
            AbilityText.text = GameControl.control.ContemptDamage.ToString();
        }
    }

    public void upgradeTime()
    {
        if (SpendPoints())
        {
            GameControl.control.Time += 5f;
            AbilityText.text = GameControl.control.Time.ToString();
        }
    }

    public void upgradeShields()
    {
        if (SpendPoints())
        {
            GameControl.control.Shields += 1;
            AbilityText.text = GameControl.control.Shields.ToString();
        }
    }

    public void upgradeTeleports()
    {
        if (SpendPoints())
        {
            GameControl.control.Teleports += 1;
            AbilityText.text = GameControl.control.Teleports.ToString();
        }
    }

    public void upgradeCalmShots()
    {
        if (SpendPoints())
        {
            GameControl.control.CalmShots += 50;
            AbilityText.text = GameControl.control.CalmShots.ToString();
        }
    }

    public void upgradeCalmDamage()
    {
        if (SpendPoints())
        {
            GameControl.control.CalmDamage += 3f;
            AbilityText.text = GameControl.control.CalmDamage.ToString();
        }
    }

    public void upgradeBursts()
    {
        if (SpendPoints())
        {
            GameControl.control.Bursts += 1;
            AbilityText.text = GameControl.control.Bursts.ToString();
        }
    }

    public void upgradeRage()
    {
        if (SpendPoints())
        {
            GameControl.control.Rage += 50f;
            AbilityText.text = GameControl.control.Rage.ToString();
        }
    }
}
