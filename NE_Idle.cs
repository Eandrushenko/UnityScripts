using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE_Idle : StateMachineBehaviour {

    Nanobot Nano;

    public float attackRate;
    private float nextAttack = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Nano = animator.GetComponent<Nanobot>();

        animator.GetComponent<BoxCollider2D>().enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAttack(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Chase");
        animator.ResetTrigger("Explode");
        animator.ResetTrigger("Open");
    }

    private void DoAttack(Animator animator)
    {
        if (Time.time > nextAttack)
        {
            if (Nano.Attack == 1)
            {
                animator.SetTrigger("Chase");
            }
            else if (Nano.Attack == 2)
            {
                animator.SetTrigger("Explode");
            }
            else if (Nano.Attack == 3)
            {
                animator.SetTrigger("Open");
            }
            nextAttack = Time.time + attackRate;
        }
    }

}
