using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text[] AbilityCounts;
    public Text Health;
    public Player player;
    public Weapon weapon;
    public AbilityController ability;
	
	// Update is called once per frame
	void Update ()
    {
        Health.text = (((int)player.currentHealth) + "/" + player.maxHealth).ToString();
        AbilityCounts[0].text = ability.heals.ToString();
        AbilityCounts[1].text = weapon.greenshots.ToString();
        displayTime();
        AbilityCounts[3].text = player.shields.ToString();
        AbilityCounts[4].text = weapon.teleports.ToString();
        AbilityCounts[5].text = weapon.purpleshots.ToString();
        AbilityCounts[6].text = ability.rages.ToString();
    }

    void displayTime()
    {
        float seconds = Mathf.FloorToInt(ability.timeleft % 60);
        float milliSeconds = (ability.timeleft % 1) * 100;

        AbilityCounts[2].text = string.Format("{0:00}:{1:00}", seconds, milliSeconds);
    }
}
