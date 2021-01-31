using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Pulse : StateMachineBehaviour {

    Colossus_Guardian cg;

    public float fireRate = 0.2f;
    private float nextFire = 0f;

    public int i;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cg = animator.GetComponent<Colossus_Guardian>();
        i = 0;
        cg.Arm2.isAggro = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > nextFire && i < 2)
        {
            cg.Pulse();
            nextFire = Time.time + fireRate;
            i++;
        }
        else
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
