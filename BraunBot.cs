using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraunBot : MonoBehaviour
{

    public EnemyController controller;
    public Animator animator;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    private bool FacingRight = true;

    private Transform player;

    public Transform firepoint;
    public Transform firepoint0;
    public Transform firepoint1;
    public Transform firepoint2;

    public LineRenderer StandardLine;
    public LayerMask layermask;

    public GameObject YellowBullet;
    public GameObject OrangeBullet;

    public GameObject BossHealthBar;

    private bool isPaused;

    private bool song1 = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (animator.GetBool("Found"))
        {
            float direction = 0f;
            if (player != null)
            {
                float distance = player.position.x - transform.position.x;
                if (distance < 0)
                {
                    direction = -1f;
                }
                else if (distance > 0)
                {
                    direction = 1f;
                }
            }

            horizontalMove = direction * runSpeed;

            LookAtPlayer();

            PillarSet();

            Music();

            BossHealthBar.SetActive(true);
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

    void PillarSet()
    {
        Enemy enemy = GetComponent<Enemy>();
        if (enemy.health < (enemy.getMaxhealth() / 2))
        {
            animator.SetBool("isPillar", true);
        }
    }

    public void OnLanding()
    {
        return;
    }

    public void Walk()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false);
        Sapper();
    }


    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else {
            return 0f;
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

    public void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("BraunShot");
        Instantiate(YellowBullet, firepoint0.position, firepoint0.rotation);
        Instantiate(YellowBullet, firepoint1.position, firepoint1.rotation);
    }

    private void Sapper()
    {
        isPaused = FindObjectOfType<Overseer>().isPaused;
        if (player != null && !isPaused)
        {
            RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, (player.position - firepoint.position), 10f, layermask);
            if (hitinfo)
            {
                Player target = hitinfo.transform.GetComponent<Player>();
                if (target != null)
                {
                    StandardLine.enabled = true;
                    target.TakeDamage(0.1f);
                    if (!FindObjectOfType<AudioManager>().isPlaying("LaserBeam"))
                    {
                        FindObjectOfType<AudioManager>().Play("LaserBeam");
                    }
                }

                StandardLine.SetPosition(0, firepoint.position);
                StandardLine.SetPosition(1, hitinfo.transform.position);
            }
            else
            {
                StandardLine.enabled = false;
            }
        }
        else
        {
            StandardLine.enabled = false;
        }
    }

    public void Stance()
    {
        FindObjectOfType<AudioManager>().Play("BraunPillar");
        Instantiate(OrangeBullet, firepoint2.position, firepoint2.rotation);
    }
}