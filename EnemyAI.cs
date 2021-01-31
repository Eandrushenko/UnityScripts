using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

    private Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rb;

    public Vector3 OffSet = new Vector3(0f, 0f, 0f);

    private bool FacingRight = true;

    public Transform firepoint;

    public GameObject bulletPrefab;

    public float fireRate = 1f;
    private float nextFire = 0f;

    public string BulletSFX;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
	}

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            FindObjectOfType<AudioManager>().Play(BulletSFX);
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    public void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (target != null)
            {
                seeker.StartPath(rb.position, (target.position + OffSet), OnPathComplete);
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

    //Disappear when hitting the ground on death
    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = GetComponent<Enemy>();
        if (!enemy.isAlive && !(other.gameObject.layer == 9)) //9 = Player_Bullet Collision layer
        {
            FindObjectOfType<AudioManager>().Play("DroneCrash");
            Destroy(gameObject);
        }
    }

    void FixedUpdate ()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //Change Direction of Enemy based on the direction it is moving
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
