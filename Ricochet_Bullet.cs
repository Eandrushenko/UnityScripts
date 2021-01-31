using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet_Bullet : MonoBehaviour
{

    private Vector3 lastFrameVelocity;
    private Rigidbody2D rb;

    public float damage = 10f;
    public float speed = 20f;
    public float impactForce = 30f;

    private float TimeToLive = 3f;

    public GameObject Collision;

    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);

            FindObjectOfType<AudioManager>().setPitch("MetalCollision", UnityEngine.Random.Range(0.7f, 0.9f));
            FindObjectOfType<AudioManager>().setVolume("MetalCollision", UnityEngine.Random.Range(0.1f, 0.2f));
            FindObjectOfType<AudioManager>().Play("MetalCollision");

            Destroy(gameObject);
            Instantiate(Collision, transform.position, transform.rotation);
        }
        else
        {
            FindObjectOfType<AudioManager>().setPitch("Ricochet", UnityEngine.Random.Range(0.7f, 0.9f));
            FindObjectOfType<AudioManager>().setVolume("Ricochet", UnityEngine.Random.Range(0.1f, 0.2f));
            FindObjectOfType<AudioManager>().Play("Ricochet");
            Bounce(collision.GetContact(0).normal);
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rb.velocity = direction * speed;
    }
}