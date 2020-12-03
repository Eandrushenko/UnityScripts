using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPCircle : MonoBehaviour {

    public Text CurXP;
    public Text NextXP;
    public Text TotalXP;
    //public Text TotalXP;

    public LevelSystem lvlsys;

    private float cur;

	// Use this for initialization
	void Start ()
    {
        cur = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        cur = Mathf.Lerp(cur, lvlsys.getCurrentXP(), Time.deltaTime * 2f);
        CurXP.text = (Mathf.FloorToInt(cur)).ToString();

        NextXP.text = Mathf.FloorToInt(lvlsys.FindXPtoNextLevel()).ToString();
        TotalXP.text = Mathf.FloorToInt(lvlsys.getTotalXP()).ToString();

        Debug.Log(cur);
    }
}
