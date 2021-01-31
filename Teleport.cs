using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public bool CanTeleport;
    public Weapon weapon;

    void OnMouseEnter()
    {
        CanTeleport = false;
        weapon.CanTeleport = false;
    }

    void OnMouseExit()
    {
        CanTeleport = true;
        weapon.CanTeleport = true;
    }
}
