using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    public Animator animator;
    public Enemy enemy;

    public Image health;

    private CanvasGroup canvasgroup;
    private float volume;

	void Start ()
    {
        canvasgroup = GetComponent<CanvasGroup>();
        volume = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        health.fillAmount = enemy.health / enemy.getMaxhealth();
        if (enemy.health <= 0f)
        {
            canvasgroup.alpha -= 0.01f;
            volume -= 0.01f;
            FindObjectOfType<AudioManager>().setVolume("Song1", volume);
        }
	}
}
