using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Braun_Walk : StateMachineBehaviour {

    BraunBot braunbot;

    public float fireRate = 40f;
    private float nextFire = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        braunbot = animator.GetComponent<BraunBot>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        braunbot.LookAtPlayer();
        braunbot.ChasePlayer();
        if (braunbot.DistanceCheck(5f))
        {
            braunbot.StartCoroutine(braunbot.Sapper());
        }
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            animator.SetTrigger("Shoot");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Shoot");
    }
}
