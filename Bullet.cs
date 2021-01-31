using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rb;

    public float damage = 10f;
    public float speed = 20f;
    public int bulletType = 0;

    private float TimeToLive = 3f;

    public GameObject Collision;

    void Start()
    {
        Destroy(gameObject, TimeToLive);
        if (bulletType == 1)
        {
            damage = GameControl.control.ContemptDamage;
        }
        else if (bulletType == 2)
        {
            damage = GameControl.control.CalmDamage;
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
            FindObjectOfType<AudioManager>().setPitch("MetalCollision", UnityEngine.Random.Range(0.9f, 1.1f));
            FindObjectOfType<AudioManager>().setVolume("MetalCollision", UnityEngine.Random.Range(0.1f, 0.2f));
            FindObjectOfType<AudioManager>().Play("MetalCollision");
        }
        else
        {
            FindObjectOfType<AudioManager>().setPitch("WallCollision", UnityEngine.Random.Range(0.9f, 1.1f));
            FindObjectOfType<AudioManager>().setVolume("WallCollision", UnityEngine.Random.Range(0.1f, 0.2f));
            FindObjectOfType<AudioManager>().Play("WallCollision");
        }

        Destroy(gameObject);
        Instantiate(Collision, transform.position, transform.rotation);
    }
}
