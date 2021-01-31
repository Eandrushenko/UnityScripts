using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nanobot : MonoBehaviour
{
    public Animator animator;

    public GameObject bosshealthbar;

    private bool song1 = true;

    public Transform firepoint;
    public GameObject bulletPrefab;

    public float fireRate = 1f;
    private float nextFire = 0f;

    public GameObject ring;

    [HideInInspector]
    public int Attack;

    public Transform[] Set1;
    public Transform[] Set2;

    public GameObject TurretBullet;

    public Enemy enemy;

    private float fireRate1 = 0.25f;
    private float nextFire1 = 0f;

    private float fireRate2 = 0.25f;
    private float nextFire2 = 0f;

    void Update()
    {
        if (animator.GetBool("Found"))
        {

            Attack = Mathf.FloorToInt(Random.Range(1, 3.99f));

            bosshealthbar.SetActive(true);

            Music();
        }

        if ((enemy.health <= enemy.getMaxhealth() / 2f) && enemy.isAlive)
        {
            FireSet2();
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

    public int Shoot(int i)
    {
        if (Time.time > nextFire)
        {
            FindObjectOfType<AudioManager>().Play("NanoShot");
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            nextFire = Time.time + fireRate;
            i -= 1;
        }
        return i;
    }

    public void Rage()
    {
        Instantiate(ring, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("NanoRage");
        animator.SetTrigger("Default");
    }

    public void Open()
    {
        animator.SetTrigger("Close");
    }

    public void FireSet1()
    {
        if (Time.time > nextFire1)
        {
            Instantiate(TurretBullet, Set1[0].position, Set1[0].rotation);
            Instantiate(TurretBullet, Set1[1].position, Set1[1].rotation);
            Instantiate(TurretBullet, Set1[2].position, Set1[2].rotation);
            Instantiate(TurretBullet, Set1[3].position, Set1[3].rotation);

            nextFire1 = Time.time + fireRate1;
        }
    }

    public void FireSet2()
    {
        if (Time.time > nextFire2)
        {
            Instantiate(TurretBullet, Set2[0].position, Set2[0].rotation);
            Instantiate(TurretBullet, Set2[1].position, Set2[1].rotation);
            Instantiate(TurretBullet, Set2[2].position, Set2[2].rotation);
            Instantiate(TurretBullet, Set2[3].position, Set2[3].rotation);
            Instantiate(TurretBullet, Set2[4].position, Set2[4].rotation);
            Instantiate(TurretBullet, Set2[5].position, Set2[5].rotation);
            Instantiate(TurretBullet, Set2[6].position, Set2[6].rotation);

            nextFire2 = Time.time + fireRate2;
        }
    }
}

