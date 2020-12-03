using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraunBot : MonoBehaviour {

    public Transform player;
    public Transform firepoint;
    public LineRenderer StandardLine;
    public LayerMask layermask;
    Rigidbody2D rb;

    public Transform shotpoint0;
    public Transform shotpoint1;
    public Transform shotpoint2;

    public GameObject BraunBullet0;
    public GameObject BraunBullet1;

    public bool FacingRight = true;

    public float currentHealth = 1000f;
    private float totalHealth;

    public bool isInvulnerable = false;

    void Start()
    {
        totalHealth = currentHealth;
        rb = GetComponent<Rigidbody2D>();
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

    public void ChasePlayer()
    {
        if (player != null)
        {
            Vector2 direction = ((Vector2)player.position - rb.position).normalized;
            Vector2 force = direction * 2000f * Time.fixedDeltaTime;
            rb.AddForce(force);
        }
    }

    public IEnumerator Sapper()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firepoint.position, firepoint.right, 20f, layermask);
        if (hitInfo && !hitInfo.transform.CompareTag("Enemy"))
        {
            Player player = hitInfo.transform.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(0.1f);
            }

            StandardLine.SetPosition(0, firepoint.position);
            StandardLine.SetPosition(1, hitInfo.point);

        }
        else
        {
            StandardLine.SetPosition(0, firepoint.position);
            StandardLine.SetPosition(1, firepoint.position + (firepoint.right * 100));
        }

        StandardLine.enabled = true;

        yield return new WaitForSeconds(0.02f);

        StandardLine.enabled = false;
    }

    public bool DistanceCheck(float AttackRange)
    {
        bool result = false;
        if (player != null)
        {
            if (Vector2.Distance(player.position, rb.position) <= AttackRange)
            {
                result = true;
            }
        }
        return result;
    }

    public void BraunShot()
    {
        Instantiate(BraunBullet0, shotpoint0.position, shotpoint0.rotation);
        Instantiate(BraunBullet0, shotpoint1.position, shotpoint1.rotation);
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= (0.4 * totalHealth))
        {
            GetComponent<Animator>().SetBool("isPillar", true);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Stance()
    {
        Instantiate(BraunBullet1, shotpoint2.position, shotpoint2.rotation);
    }


}
