using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour {

    private Rigidbody2D rb;

    public float damage = 10f;
    public float speed = 20f;

    public float TimeToLive = 4f;

    public float Accuracy = 0f; //The lower the better, 0 = perfect accuracy

    public GameObject Collision;

    public string wallcollision;
    public string playercollision;

    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(((transform.right.x * speed) + Random.Range(-Accuracy, Accuracy)), ((transform.right.y * speed) + Random.Range(-Accuracy, Accuracy)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            FindObjectOfType<AudioManager>().Play(playercollision);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play(wallcollision);
        }

        Destroy(gameObject);
        Instantiate(Collision, transform.position, transform.rotation);
    }
}
