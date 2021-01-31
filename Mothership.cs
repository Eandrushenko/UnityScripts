using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{

    public Transform[] Firepoints; //[0] = Cannon Firepoint, [1-5] = Gunfleet

    public Animator animator;

    private bool song1 = true;

    public GameObject CannonBullet;
    public GameObject GunfleetBullet;

    public float fireRate = 0.5f;
    private float nextFire = 0f;

    [HideInInspector]
    public int GlobalCounter;

    [HideInInspector]
    public int Attack;

    public GameObject bosshealthbar;

    public LineRenderer StandardLine;
    public Transform Zapper;

    public Transform SummonSpot;

    public GameObject Gunship;
    public GameObject Gunship_Teleport;

    private Transform player;

    private float rotationZ = 0f;
    public Transform SurgePivot;
    public GameObject SurgeBullet;

    public Enemy enemy;

    private float fireRate2 = 0.1f;
    private float nextFire2 = 0f;

    private bool playonce = true;

    public GameObject Explosion;
    public Renderer render;

    public Rigidbody2D prb;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (animator.GetBool("Found"))
        {
            Attack = Mathf.FloorToInt(Random.Range(1, 3.99f));

            bosshealthbar.SetActive(true);

            Music();
        }

        if ((enemy.health <= enemy.getMaxhealth() / 2f) && enemy.isAlive)
        {
            if (playonce)
            {
                FindObjectOfType<AudioManager>().Play("MS_Shift");
                playonce = false;
            }
            Surge();
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

    public void GunfleetFire()
    {
        if (Time.time > nextFire)
        {
            FindObjectOfType<AudioManager>().Play("GS_Bullet");
            Instantiate(GunfleetBullet, Firepoints[1].position, Firepoints[1].rotation);
            Instantiate(GunfleetBullet, Firepoints[2].position, Firepoints[2].rotation);
            Instantiate(GunfleetBullet, Firepoints[3].position, Firepoints[3].rotation);
            Instantiate(GunfleetBullet, Firepoints[4].position, Firepoints[4].rotation);
            Instantiate(GunfleetBullet, Firepoints[5].position, Firepoints[5].rotation);
            nextFire = Time.time + fireRate;
            GlobalCounter++;
        }
    }

    public void CannonFire()
    {
        FindObjectOfType<AudioManager>().Play("MS_Pulse");
        Instantiate(CannonBullet, Firepoints[0].position, Firepoints[0].rotation);
        GlobalCounter++;
    }

    public void Spawn()
    {
        if (player != null)
        {
            SummonSpot.position = new Vector3(Random.Range(-20f, 20f), Random.Range(1f, 10f), 0f);
            StartCoroutine(Zap());
        }
    }

    public IEnumerator Zap()
    {
        StandardLine.SetPosition(0, Zapper.position);
        StandardLine.SetPosition(1, SummonSpot.position);
        StandardLine.enabled = true;

        Instantiate(Gunship_Teleport, SummonSpot.position, SummonSpot.rotation);
        Instantiate(Gunship, SummonSpot.position, SummonSpot.rotation);

        FindObjectOfType<AudioManager>().Play("Dark_Teleport");

        yield return new WaitForSeconds(0.5f);

        StandardLine.enabled = false;
    }

    private void Surge()
    {
        rotationZ += 2f;

        SurgePivot.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ >= 359f)
        {
            rotationZ = 0f;
        }

        SurgeShot();
    }

    private void SurgeShot()
    {
        if (Time.time > (nextFire2))
        {
            FindObjectOfType<AudioManager>().Play("SurgeBullet");
            Instantiate(SurgeBullet, SurgePivot.position, SurgePivot.rotation);

            nextFire2 = Time.time + fireRate2;
        }
    }

    public void Explode(int i)
    {
        FindObjectOfType<AudioManager>().Play("Explosion1");
        Instantiate(Explosion, Firepoints[i].position, Firepoints[i].rotation);
    }

    IEnumerator GoAway()
    {
        render.material.color = Color.black;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject, 5f);
        prb.gravityScale = -1f;
    }

    public void runGoAway()
    {
        StartCoroutine(GoAway());
    }
}
