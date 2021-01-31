using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public Renderer indicator;

    public GameObject door;

	// Use this for initialization
	void Start ()
    {
        indicator.material.color = Color.red;
	}
	

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Key"))
        {
            indicator.material.color = Color.green;
            door.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Success");
        }
    }
}
