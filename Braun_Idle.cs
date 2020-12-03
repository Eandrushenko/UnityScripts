using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Braun_Idle : StateMachineBehaviour {

    BraunBot braunbot;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        braunbot = animator.GetComponent<BraunBot>();
        braunbot.isInvulnerable = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (braunbot.DistanceCheck(20f))
        {
            animator.SetTrigger("Start");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        braunbot.isInvulnerable = false;
    }

}
