using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlayerController controller;
    public Animator animator;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jumpFlag = false;
    private bool jump = false;

    public RuntimeAnimatorController regularController;
    public RuntimeAnimatorController ShieldController;

    private bool isPaused;

    void Update()
    {
        isPaused = FindObjectOfType<Overseer>().isPaused;
        if (!isPaused)
        {
            AbilityController checker = GetComponent<AbilityController>();
            if (checker.Active[4])
            {
                animator.runtimeAnimatorController = ShieldController;
            }
            else
            {
                animator.runtimeAnimatorController = regularController;
            }

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (jumpFlag)
            {
                animator.SetBool("IsJumping", true);
                jumpFlag = false;
            }
            if (Input.GetButtonDown("Jump") || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                jump = true;
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
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
