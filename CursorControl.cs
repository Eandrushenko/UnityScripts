using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour {

    private AbilityController Ability;
    private Weapon weapon;

    public Texture2D Aim1;
    public Texture2D Aim2;
    public Texture2D Aim3;
    public Texture2D TeleportOpen;
    public Texture2D TeleportClosed;
	
    void Start()
    {
        Ability = GetComponent<AbilityController>();
        weapon = GetComponent<Weapon>();
    }

	// Update is called once per frame
	void Update ()
    {
        GetCursor();
	}

    void GetCursor()
    {
        if (GameControl.control.Cursor == 0)
        {
            if (Ability.Active[0])
            {
                Cursor.SetCursor(Aim1, Vector2.zero, CursorMode.ForceSoftware);
            }
            if (Ability.Active[2])
            {
                Cursor.SetCursor(Aim2, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (Ability.Active[6])
            {
                Cursor.SetCursor(Aim3, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (Ability.Active[5])
            {
                if (weapon.CanTeleport)
                {
                    Vector2 hotSpot = new Vector2(TeleportOpen.width / 2f, TeleportOpen.height / 2f);
                    Cursor.SetCursor(TeleportOpen, hotSpot, CursorMode.ForceSoftware);
                }
                else
                {
                    Vector2 hotSpot = new Vector2(TeleportClosed.width / 2f, TeleportClosed.height / 2f);
                    Cursor.SetCursor(TeleportClosed, hotSpot, CursorMode.ForceSoftware);
                }
            }
            else
            {
                Cursor.SetCursor(Aim1, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
        else if (GameControl.control.Cursor == 1)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
