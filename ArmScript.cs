using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour {

    public GameObject Arm0;
    public GameObject Arm1;
    public Sprite[] ArmSprites;

	// Update is called once per frame
	void Update ()
    {
        AbilityController checker = GetComponent<AbilityController>();
        if (Input.GetButton("Fire1"))
        {
            if (checker.Active[2])
            {
                Arm0.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[2];
                Arm1.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[2];
            }
            else if (checker.Active[6])
            {
                Arm0.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[3];
                Arm1.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[3];
            }
            else if (checker.Active[5])
            {
                Arm0.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[4];
                Arm1.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[4];
            }
            else
            {
                Arm0.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[1];
                Arm1.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[1];
            }
        }
        else
        {
            Arm0.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[0];
            Arm1.gameObject.GetComponent<SpriteRenderer>().sprite = ArmSprites[0];
        }
    }
}
