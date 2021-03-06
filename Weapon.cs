﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	
    public Transform firepoint0;
    public Transform firepoint1;

    public GameObject[] bulletPrefabs;

    public GameObject Teleport;

    public float fireRate = 0.25f; //The lower the faster 0 = maximum fire rate
    private float nextFire = 0f;

    public int greenshots = 10;
    public int purpleshots = 50;
    public int teleports = 2;

    public bool CanTeleport;

    private bool isPaused;

    void Start()
    {
        greenshots = GameControl.control.ContemptShots;
        purpleshots = GameControl.control.CalmShots;
        teleports = GameControl.control.Teleports;
    }

	// Update is called once per frame
	void Update ()
    {
        isPaused = FindObjectOfType<Overseer>().isPaused;
        if (!isPaused)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                Shoot();
                nextFire = Time.time + fireRate;
            }
        }
	}

    void Shoot()
    {
        AbilityController checker = GetComponent<AbilityController>();
        if (checker.Active[2] && greenshots > 0)
        {
            Instantiate(bulletPrefabs[1], firepoint0.position, firepoint0.rotation);
            Instantiate(bulletPrefabs[1], firepoint1.position, firepoint1.rotation);
            greenshots -= 2;
            FindObjectOfType<AudioManager>().Play("Bullet2");
            fireRate = 1f;
        }
        else if (checker.Active[6] && purpleshots > 0)
        {
            Instantiate(bulletPrefabs[2], firepoint0.position, firepoint0.rotation);
            Instantiate(bulletPrefabs[2], firepoint1.position, firepoint1.rotation);
            purpleshots -= 2;
            FindObjectOfType<AudioManager>().Play("Bullet3");
            fireRate = 0.1f;
        }
        else if (checker.Active[5] && teleports > 0)
        {
            if (CanTeleport)
            {
                Instantiate(Teleport, transform.position, transform.rotation);
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
                Instantiate(Teleport, transform.position, transform.rotation);
                teleports -= 1;
                FindObjectOfType<AudioManager>().Play("Teleport");
            }
        }
        else if (!checker.Active[2] && !checker.Active[6] && !checker.Active[5])
        {
            Instantiate(bulletPrefabs[0], firepoint0.position, firepoint0.rotation);
            Instantiate(bulletPrefabs[0], firepoint1.position, firepoint1.rotation);
            FindObjectOfType<AudioManager>().Play("Bullet1");
            fireRate = 0.25f;

        }
    }
}
