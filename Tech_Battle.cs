using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tech_Battle : StateMachineBehaviour {

    Technomancer technomancer;
    Enemy enemy;

    public float attackRate;
    private float nextAttack = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        technomancer = animator.GetComponent<Technomancer>();
        enemy = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAttack(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Stance");
        animator.ResetTrigger("Triple");
        animator.ResetTrigger("Gale");
        animator.ResetTrigger("Teleport");
        animator.ResetTrigger("Rain");
    }

    private void DoAttack(Animator animator)
    {
        if (enemy.health <= enemy.getMaxhealth() / 3f)
        {
            animator.SetTrigger("Rain");
        }
        else if (Time.time > nextAttack)
        {
            if (technomancer.Attack == 1)
            {
                animator.SetTrigger("Stance");
            }
            else if (technomancer.Attack == 2)
            {
                animator.SetTrigger("Triple");
            }
            else if (technomancer.Attack == 3)
            {
                animator.SetTrigger("Gale");
            }
            else if (technomancer.Attack == 4)
            {
                animator.SetTrigger("Teleport");
            }
            nextAttack = Time.time + attackRate;
        }
    }
}
