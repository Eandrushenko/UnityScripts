using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageRingScript : MonoBehaviour
{

    public float damage = 200f;

    private float TimeToLive = 0.35f;

    // Use this for initialization
    void Start()
    {
        damage = PlayerPrefs.GetFloat("Rage", damage);
        Destroy(gameObject, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.2f, 0.2f, 0f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
