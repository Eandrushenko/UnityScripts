using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDrone : MonoBehaviour {

    public Rigidbody2D rb;

    private Vector2 GoToSpot;

    public float Speed;
    private bool FacingRight = true;

    public Enemy enemy;

    void Start()
    {
        GoToSpot = transform.position;
    }

    void Update()
    {
        if (enemy.isAlive)
        {
            Vector2 direction = (GoToSpot - rb.position).normalized;
            Vector2 force = direction * Speed * Time.deltaTime;

            rb.AddForce(force);

            if (Mathf.Abs(GoToSpot.x - rb.position.x) >= 0.25f || Mathf.Abs(GoToSpot.y - rb.position.y) >= 0.25f)
            {
                LookAtDestination();
            }
        }
        else
        {
            rb.gravityScale = 5f;
        }
    }

    public void LookAtDestination()
    {
            if ((transform.position.x > GoToSpot.x) && FacingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                FacingRight = false;
            }
            else if ((transform.position.x < GoToSpot.x) && !FacingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                FacingRight = true;
            }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = GetComponent<Enemy>();
        if (!enemy.isAlive && !(other.gameObject.layer == 9)) //9 = Player_Bullet Collision layer
        {
            FindObjectOfType<AudioManager>().Play("DroneCrash");
            Destroy(gameObject);
        }
    }
}
