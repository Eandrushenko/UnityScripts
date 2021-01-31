using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {

    public GameObject Bolt;
    public GameObject Bolt2;

    public GameObject C1;
    public GameObject C2;
    public GameObject C3;

    public GameObject Explosion;

    public Vector3 E1;

    public GameObject player;
    public Player health;

    private CameraFollow CF;

    public GameObject UI;

    public GameObject enemy;

	// Use this for initialization
	void Start ()
    {
        CF = C3.GetComponent<CameraFollow>();
        CF.enabled = false;
	}

    public void LightningStrikeON()
    {
        FindObjectOfType<AudioManager>().Play("Thunder");
        Bolt.SetActive(true);
    }

    public void LightningStrikeOff()
    {
        Bolt.SetActive(false);
    }

    public void C1C2()
    {
        C1.SetActive(false);
        C2.SetActive(true);
    }

    public void Strike2On()
    {
        FindObjectOfType<AudioManager>().Play("Thunder");
        Bolt2.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Explosion1");
        Instantiate(Explosion, E1, Quaternion.identity);
    }

    public void Strike2Off()
    {
        Bolt2.SetActive(false);
        C2.SetActive(false);
        C3.SetActive(true);
    }

    public void Explode()
    {
        Instantiate(Explosion, player.transform.position, Quaternion.identity);
    }

    public void StartGame()
    {
        player.SetActive(true);
    }

    public void SetHealth()
    {
        health.currentHealth = health.maxHealth / 2;
        CF.enabled = true;
        UI.SetActive(true);
        enemy.SetActive(true);
    }


}
