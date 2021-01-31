using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour {

    public Text CurrentLevel;
    public Text NextLevel;
    public Image BarFill;

    public LevelSystem lvlsys;
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (lvlsys.getLevel() < 50)
        {
            BarFill.fillAmount = Mathf.Lerp(BarFill.fillAmount, lvlsys.GetRatio(), Time.deltaTime * 2f);
            CurrentLevel.text = lvlsys.getLevel().ToString();
            NextLevel.text = (lvlsys.getLevel() + 1).ToString();
        }
        else
        {
            BarFill.fillAmount = 1;
            CurrentLevel.text = "50";
            NextLevel.text = "MAX";
            NextLevel.fontSize = 22;
        }
    }
}
