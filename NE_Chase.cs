using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE_Chase : StateMachineBehaviour {

    EnemyAI AI;
    Nanobot Nano;

    int firecount;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AI = animator.GetComponent<EnemyAI>();
        Nano = animator.GetComponent<Nanobot>();

        AI.InvokeRepeating("UpdatePath", 0f, 0.5f);
        firecount = 40;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (firecount >= 0)
        {
            firecount = Nano.Shoot(firecount);
        }
        else
        {
            animator.SetTrigger("Default");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AI.CancelInvoke();
        animator.ResetTrigger("Default");
    }
}
