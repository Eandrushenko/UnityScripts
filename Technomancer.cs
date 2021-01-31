using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Technomancer : MonoBehaviour {

    private Transform player;

    public Transform shot1;
    public Transform shot2;
    public Transform shot3;

    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;

    public GameObject teleport;

    private bool FacingRight = true;

    public Animator animator;

    public GameObject bosshealthbar;

    [HideInInspector]
    public int Attack;

    private Enemy enemy;
    private Rigidbody2D rb;

    public GameObject Explosion;

    public GameObject rain;

    private bool song1 = true;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (animator.GetBool("Found"))
        {
            LookAtPlayer();

            Attack = Mathf.FloorToInt(Random.Range(1, 4.99f));

            bosshealthbar.SetActive(true);

            Music();
        }
        if (!enemy.isAlive)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 5f;
        }
    }

    public void LookAtPlayer()
    {
        if (player != null)
        {
            if ((transform.position.x > player.position.x) && FacingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                FacingRight = false;
            }
            else if ((transform.position.x < player.position.x) && !FacingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                FacingRight = true;
            }
        }
    }

    public void Single()
    {
        Instantiate(Bullet2, shot2.position, shot2.rotation);
        FindObjectOfType<AudioManager>().Play("Single");
    }

    public void Teleport()
    {
        Instantiate(teleport, transform.position, transform.rotation);
        transform.position = new Vector3(Random.Range(-8f, 75f), 7f, transform.position.z);
        Instantiate(teleport, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("DarkPort");
    }

    public void Stance()
    {
        Instantiate(Bullet1, shot1.position, shot1.rotation);
        FindObjectOfType<AudioManager>().Play("StaffShot");
    }

    public void Gale()
    {
        Instantiate(Bullet3, shot3.position, shot3.rotation);
        FindObjectOfType<AudioManager>().Play("Woosh");
    }

    public void Rain()
    {
        rain.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Laugh");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!enemy.isAlive && !(other.gameObject.layer == 9)) //9 = Player_Bullet Collision layer
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("DroneCrash");
            Destroy(gameObject);
        }
    }

    void Music()
    {
        if (animator.GetBool("Found") && song1)
        {
            song1 = false;
            FindObjectOfType<AudioManager>().PlayLoop("Song1");
        }
    }
}
