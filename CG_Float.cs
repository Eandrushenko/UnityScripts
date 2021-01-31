using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Float : StateMachineBehaviour {

    Rigidbody2D rb;
    Guardian_Flight gf;
    Colossus_Guardian cg;
    Enemy enemy;

    public float attackRate;
    private float nextAttack = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        gf = animator.GetComponent<Guardian_Flight>();
        cg = animator.GetComponent<Colossus_Guardian>();
        enemy = animator.GetComponent<Enemy>();

        rb.mass = 100f;
        rb.gravityScale = 0f;

        cg.DefaultPosition();
        cg.Arm1.isAggro = false;
        cg.Arm2.isAggro = false;
        cg.animatorARM.SetBool("Active", false);

        gf.flight = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAttack(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Pulse");
        animator.ResetTrigger("Launch");
        animator.ResetTrigger("Summon");
        animator.ResetTrigger("SET");
    }

    private void DoAttack(Animator animator)
    {
        if (enemy.health <= enemy.getMaxhealth() / 10f)
        {
            animator.SetTrigger("SET");
        }
        else if (Time.time > nextAttack)
        {
            if (cg.Attack == 1)
            {
                animator.SetTrigger("Pulse");
            }
            else if (cg.Attack == 2)
            {
                animator.SetTrigger("Launch");
            }
            else if (cg.Attack == 3)
            {
                animator.SetTrigger("Summon");
            }
            nextAttack = Time.time + attackRate;
        }
    }
}
