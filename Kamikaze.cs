using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
public class Kamikaze : MonoBehaviour {

    Transform target;
    public Animator animator;

    public float speed = 5;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    private bool FacingRight = true;

    public Transform firepoint;

    public GameObject bulletPrefab;

    public GameObject Collision;

    public float fireRate = 1f;
    private float nextFire = 0f;

    public float ContactDamage;

    //Seeker Script Variables
    Seeker seeker;

    Path path;
    int currentWaypoint = 0;
    public float nextWaypointDistance = 3f;


    void Start()
    {
        //If player exists shoot at player, otherwise shoot somewhere else
        //This if else is here to remove nullreference errors on player death
        target = GameObject.FindWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target != null && animator.GetBool("Found"))
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

            if (rb.velocity.x >= 0.01f) //force.x instead of rb.velocity.x would be better but it's buggy
            {
                if (FacingRight == false)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    FacingRight = true;
                }
            }
            else if (rb.velocity.x <= -0.01f)
            {
                if (FacingRight == true)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    FacingRight = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            FindObjectOfType<AudioManager>().Play("Explosion1");
            player.TakeDamage(ContactDamage);
            Destroy(gameObject);
            Instantiate(Collision, transform.position, transform.rotation);
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

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            FindObjectOfType<AudioManager>().Play("KShot");
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}