using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {

    public GameObject TitleScreen;
    public GameObject CampaignScreen;

    public XPCircle stats;

    public Texture2D Aim0;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1f;

        if (GameControl.control.MM == 0)
        {
            TitleScreen.SetActive(true);
        }
        else
        {
            CampaignScreen.SetActive(true);
        }
        stats.DisplayStats();
	}

    void Update()
    {
        if (GameControl.control.Cursor == 0)
        {
            Cursor.SetCursor(Aim0, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (GameControl.control.Cursor == 1)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
