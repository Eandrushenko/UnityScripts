using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rb;

    public float damage = 10f;
    public float speed = 20f;
    public float impactForce = 30f;
    public int bulletType = 0;

    private float TimeToLive = 3f;

    public GameObject Collision;

    void Start()
    {
        Destroy(gameObject, TimeToLive);
        if (bulletType == 1)
        {
            damage = PlayerPrefs.GetFloat("ContemptDamage", damage);
        }
        else if (bulletType == 2)
        {
            damage = PlayerPrefs.GetFloat("CalmDamage", damage);
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            if (enemy.GetComponent<Rigidbody2D>() != null)
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(transform.right * impactForce);
            }
        }

        Destroy(gameObject);
        Instantiate(Collision, transform.position, transform.rotation);
    }
}
