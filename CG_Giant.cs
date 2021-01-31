using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Giant : StateMachineBehaviour {

    Guardian_Giant gg;
    Guardian_Flight gf;
    Colossus_Guardian cg;

    public float attackRate;
    private float nextAttack = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gg = animator.GetComponent<Guardian_Giant>();
        gf = animator.GetComponent<Guardian_Flight>();
        cg = animator.GetComponent<Colossus_Guardian>();

        gf.FinalPhase = true;

        cg.DefaultPosition();
        cg.Arm1.isAggro = false;
        cg.Arm2.isAggro = false;
        cg.animatorARM.SetBool("Active", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAttack(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Rockets");
        animator.ResetTrigger("Summon");
        animator.ResetTrigger("Launch");
    }

    private void DoAttack(Animator animator)
    {
        if (Time.time > nextAttack)
        {
            if (gg.Attack == 1)
            {
                animator.SetTrigger("Rockets");
            }
            else if (gg.Attack == 2)
            {
                animator.SetTrigger("Summon");
            }
            else if (gg.Attack == 3)
            {
                animator.SetTrigger("Launch");
            }
            nextAttack = Time.time + attackRate;
        }
    }
}
