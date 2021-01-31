﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE_Explode : StateMachineBehaviour {

    Nanobot Nano;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Nano = animator.GetComponent<Nanobot>();
        rb = animator.GetComponent<Rigidbody2D>();
        Nano.Invoke("Rage", 3f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Default");
    }
}
