using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_State : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyAI killspeed = animator.GetComponent<EnemyAI>();
        killspeed.speed = 0f;

        Rigidbody2D dropoff = animator.GetComponent<Rigidbody2D>();
        dropoff.gravityScale = 3f;

        Detection targeting = animator.GetComponent<Detection>();
        targeting.pivot.isAggro = false;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
