using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_GiantSummon : StateMachineBehaviour {

    Guardian_Giant gg;

    public float fireRate = 1f;
    private float nextFire = 0f;

    private int i = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gg = animator.GetComponent<Guardian_Giant>();

        i = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > nextFire && i < 2)
        {
            gg.Spawn();
            nextFire = Time.time + fireRate;
            i++;
        }
        else if (i >= 2)
        {
            animator.SetTrigger("Default");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Default");
    }
}
