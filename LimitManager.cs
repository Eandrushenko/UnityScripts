using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitManager : MonoBehaviour {

    public Button[] button;

    /*

    0 - Health
    1 - Heals
    2 - Contempt Shots
    3 - Contempt Damage
    4 - Time
    5 - Shields
    6 - Teleports
    7 - Calm Shots
    8 - Calm Damage
    9 - Rages
    10 - Rage Damage

    */
	
	// Update is called once per frame
	void Update ()
    {
		if (GameControl.control.Health >= 500f)
        {
            button[0].interactable = false;
        }
        else
        {
            button[0].interactable = true;
        }

        if (GameControl.control.Heals >= 8)
        {
            button[1].interactable = false;
        }
        else
        {
            button[1].interactable = true;
        }

        if (GameControl.control.ContemptShots >= 30)
        {
            button[2].interactable = false;
        }
        else
        {
            button[2].interactable = true;
        }

        if (GameControl.control.ContemptDamage >= 100f)
        {
            button[3].interactable = false;
        }
        else
        {
            button[3].interactable = true;
        }

        if (GameControl.control.Time >= 30f)
        {
            button[4].interactable = false;
        }
        else
        {
            button[4].interactable = true;
        }

        if (GameControl.control.Shields >= 5)
        {
            button[5].interactable = false;
        }
        else
        {
            button[5].interactable = true;
        }

        if (GameControl.control.Teleports >= 2)
        {
            button[6].interactable = false;
        }
        else
        {
            button[6].interactable = true;
        }

        if (GameControl.control.CalmShots >= 400)
        {
            button[7].interactable = false;
        }
        else
        {
            button[7].interactable = true;
        }

        if (GameControl.control.CalmDamage >= 15f)
        {
            button[8].interactable = false;
        }
        else
        {
            button[8].interactable = true;
        }

        if (GameControl.control.Bursts >= 1)
        {
            button[9].interactable = false;
        }
        else
        {
            button[9].interactable = true;
        }

        if (GameControl.control.Rage >= 500f)
        {
            button[10].interactable = false;
        }
        else
        {
            button[10].interactable = true;
        }
    }


}
