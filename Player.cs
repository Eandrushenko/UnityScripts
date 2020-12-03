using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject Bar;
    public GameObject BarSprite;

    public Text HealthTitle;
    public Text HealthValue;

    //public GameObject deathEffect;

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public int shields = 5;

    void Start()
    {
        maxHealth = PlayerPrefs.GetFloat("Health", maxHealth);
        currentHealth = maxHealth;
        shields = PlayerPrefs.GetInt("Shields", shields);
    }

    // Update is called once per frame
    void Update()
    {
        scaleConversion();
        barColor();
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
	}

    private void scaleConversion()
    {
        float convertedHealth = currentHealth / maxHealth;

        Vector3 Healthchange = new Vector3(1f, convertedHealth, 1f);
        Bar.transform.localScale = Healthchange;
    }

    private void barColor()
    {
        float convertedHealth = currentHealth / maxHealth;

        if (convertedHealth > 0.66f)
        {
            BarSprite.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 1f); //Turn color of BarSprite to Green
            HealthTitle.color = new Color(0f, 1f, 0f, 1f);
            HealthValue.color = new Color(0f, 1f, 0f, 1f);
        }
        else if (convertedHealth > 0.33f)
        {
            BarSprite.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0f, 1f); //Turn color of BarSprite to Yellow
            HealthTitle.color = new Color(1f, 1f, 0f, 1f);
            HealthValue.color = new Color(1f, 1f, 0f, 1f);
        }
        else
        {
            BarSprite.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 1f); //Turn color of BarSprite to Red
            HealthTitle.color = new Color(1f, 0f, 0f, 1f);
            HealthValue.color = new Color(1f, 0f, 0f, 1f);
        }
    }

    public void TakeDamage(float damage)
    {
        AbilityController interrupt = GetComponent<AbilityController>();

        if (interrupt.Active[4])
        {
            interrupt.Active[4] = false;
            shields -= 1;
            return;
        }
        interrupt.Active[1] = false;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
