﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100f;
    private float maxhealth;

    public float XP = 0f;
    private bool XPGiver;

    public bool isAlive = true;

    public string deathsound;

    public bool isInvulernable = false;

    void Start()
    {
        maxhealth = health;
        XPGiver = true;
    }

    //For checking the Maxhealth in the Detection.cs Script so that enemies can detect the player when damaged
    //While also keeping the maxhealth value private
    public float getMaxhealth()
    {
        return maxhealth;
    }

    public void TakeDamage(float damage)
    {
        if (isInvulernable)
        {
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            isAlive = false;
            GiveXP();
            GetComponent<Animator>().SetBool("isDead", true);
        }
    }

    private void GiveXP()
    {
        if (XPGiver == true)
        {
            FindObjectOfType<AudioManager>().Play(deathsound);
            GameObject player = GameObject.FindWithTag("Player");
            LevelSystem lvlsys = player.GetComponent<LevelSystem>();
            if (lvlsys != null)
            {
                lvlsys.AddExperience(XP);
            }
            XPGiver = false;
        }
    }
}
