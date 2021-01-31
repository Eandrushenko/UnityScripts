using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_Gunfleet : StateMachineBehaviour {

    Mothership mothership;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mothership = animator.GetComponent<Mothership>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (mothership.GlobalCounter < 5)
        {
            mothership.GunfleetFire();
        }
        else
        {
            animator.SetTrigger("Default");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mothership.GlobalCounter = 0;
        animator.ResetTrigger("Default");
    }
}
