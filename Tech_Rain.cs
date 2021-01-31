﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tech_Rain : StateMachineBehaviour {

    Transform transform;

    Technomancer technomancer;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        technomancer = animator.GetComponent<Technomancer>();
        transform = technomancer.transform;
        animator.GetComponent<Rigidbody2D>().gravityScale = 0f;

        technomancer.Rain();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(42f, 15f), 15 * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
