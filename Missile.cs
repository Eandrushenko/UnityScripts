using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour {

    Transform target;

    public float speed = 5;
    public float rotateSpeed = 200f;

    public float damage = 50f;
    public float impactForce = 5f;

    private Rigidbody2D rb;

    public GameObject Collision; 

    //Seeker Script Variables
    Seeker seeker;

    Path path;
    int currentWaypoint = 0;
    public float nextWaypointDistance = 3f;

    void Start()
    {
        //If player exists shoot at player, otherwise shoot somewhere else
        //This if else is here to remove nullreference errors on player death
        if (GameObject.FindWithTag("Player") != null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        else
        {
            target = transform;
        }
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (path == null)
            {
                return;
            }
            if (currentWaypoint >= path.vectorPath.Count)
            {
                return;
            }

            Vector2 direction = (Vector2)path.vectorPath[currentWaypoint] - rb.position;

            direction.Normalize();

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);

            if (player.GetComponent<Rigidbody2D>() != null)
            {
                player.GetComponent<Rigidbody2D>().AddForce(transform.right * impactForce);
            }
        }

        Destroy(gameObject);
        Instantiate(Collision, transform.position, transform.rotation);
    }

    //Seeker Script Functions
    public void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (target != null)
            {
                seeker.StartPath(rb.position, (target.position), OnPathComplete);
            }
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}