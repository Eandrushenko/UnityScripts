using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Setup : StateMachineBehaviour {

    Guardian_Flight gf;
    Rigidbody2D rb;

    float curHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gf = animator.GetComponent<Guardian_Flight>();
        rb = animator.GetComponent<Rigidbody2D>();

        gf.flight = false;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gf.GOTO_DropPoint();

        if (gf.CheckPoint())
        {
            rb.mass = 10000f;
            rb.gravityScale = 10f;
            animator.SetTrigger("Grow");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Grow");
    }
}
