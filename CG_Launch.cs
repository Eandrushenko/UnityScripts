using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Launch : StateMachineBehaviour {

    Colossus_Guardian cg;
    Enemy enemy;

    public float fireRate = 0.1f;
    private float nextFire = 0f;

    private int i = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cg = animator.GetComponent<Colossus_Guardian>();
        i = 0;
        cg.animatorARM.SetBool("Active", true);
        cg.Arm1.isAggro = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            i++;
            if (i == 30)
            {
                cg.Launch();
            }
            else if (i > 30)
            {
                animator.SetTrigger("Default");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Default");
    }
}
