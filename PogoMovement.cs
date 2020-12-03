using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoMovement : MonoBehaviour {

    public EnemyController controller;
    public Animator animator;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jumpFlag = false;
    private bool jump = false;

    private bool FacingRight = true;

    public Transform player;

    public Transform[] firepoints;

    public GameObject bulletPrefab;

    public float fireRate = 1f;
    private float nextFire = 0f;

    public float jumpRate = 10f;
    private float nextJump = 10f;

    void Start()
    {
        nextJump = jumpRate;
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

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (jumpFlag)
            {
                animator.SetBool("IsJumping", true);
                jumpFlag = false;
            }
            Shoot();
            JumpTime();
        }
    }



    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        if (animator.GetBool("Found"))
        {
            // move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump);

            if (jump)
            {
                jumpFlag = true;
                jump = false;
            }
        }
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
        if (Time.time > nextFire)
        {
            Instantiate(bulletPrefab, firepoints[0].position, firepoints[0].rotation);
            Instantiate(bulletPrefab, firepoints[1].position, firepoints[1].rotation);
            Instantiate(bulletPrefab, firepoints[2].position, firepoints[2].rotation);
            Instantiate(bulletPrefab, firepoints[3].position, firepoints[3].rotation);
            Instantiate(bulletPrefab, firepoints[4].position, firepoints[4].rotation);
            nextFire = Time.time + fireRate;
        }
    }

    public void JumpTime()
    {
        if (Time.time > nextJump)
        {
            jump = true;
            nextJump = Time.time + jumpRate;
        }
    }
}
