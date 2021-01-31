using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye_Attack : StateMachineBehaviour {

    EnemyAI AI;
    Eye_Drone Eye;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AI = animator.GetComponent<EnemyAI>();
        Eye = animator.GetComponent<Eye_Drone>();
        AI.InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Eye.Sapper();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
