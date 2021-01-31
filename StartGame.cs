using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public Text flash;

    private bool isOn = false;

    private float flashRate = 1f;
    private float nextFlash = 0f;

    public GameObject Title;

    private bool once = true;

    public GameObject X5Z5;



	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (Time.time > nextFlash)
        {
            if (isOn)
            {
                flash.color = Color.white;
            }
            else
            {
                flash.color = Color.black;
            }
            nextFlash = Time.time + flashRate;
            isOn = !isOn;
        }

        if (Input.GetButtonDown("Fire1") && once)
        {
            Title.SetActive(false);
            once = false;
            X5Z5.SetActive(true);
        }
	}
}
