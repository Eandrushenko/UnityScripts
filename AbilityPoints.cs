using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPoints : MonoBehaviour
{
    public Text AbilityText;
    public Text apText;

    public string PrefName;
    public float increaseValue;
    public float initialValue;
    public bool isFloat;

    //TODO: Add a cap for upgrades

    public void SpendPoints()
    {
        int ap = PlayerPrefs.GetInt("AP", 0);
        if (ap > 0)
        {
            upgradeitem();

            ap -= 1;
            PlayerPrefs.SetInt("AP", ap);
            apText.text = PlayerPrefs.GetInt("AP", 0).ToString();
        }
    }

    private void upgradeitem()
    {
        if (isFloat)
        {
            float ability = PlayerPrefs.GetFloat(PrefName, initialValue);
            ability += increaseValue;
            PlayerPrefs.SetFloat(PrefName, ability);
            AbilityText.text = PlayerPrefs.GetFloat(PrefName, initialValue).ToString();
        }
        else
        {
            //Convert Float to Int
            int initV = (int)initialValue;
            int incV = (int)increaseValue;

            int ability = PlayerPrefs.GetInt(PrefName, initV);
            ability += incV;
            PlayerPrefs.SetInt(PrefName, ability);
            AbilityText.text = PlayerPrefs.GetInt(PrefName, initV).ToString();
        }
    }
}
