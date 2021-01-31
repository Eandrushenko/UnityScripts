using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_Battle : StateMachineBehaviour {

    Mothership mothership;

    public float attackRate;
    private float nextAttack = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mothership = animator.GetComponent<Mothership>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAttack(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Gunfleet");
        animator.ResetTrigger("Cannon");
        animator.ResetTrigger("Summon");
    }

    private void DoAttack(Animator animator)
    {
        if (Time.time > nextAttack)
        {
            if (mothership.Attack == 1)
            {
                animator.SetTrigger("Gunfleet");
            }
            else if (mothership.Attack == 2)
            {
                animator.SetTrigger("Cannon");
            }
            else if (mothership.Attack == 3)
            {
                animator.SetTrigger("Summon");
            }
            nextAttack = Time.time + attackRate;
        }
    }
}
