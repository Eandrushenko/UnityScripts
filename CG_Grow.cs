using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Grow : StateMachineBehaviour {

    Guardian_Flight gf;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gf = animator.GetComponent<Guardian_Flight>();
        enemy = animator.GetComponent<Enemy>();

        gf.HealthBar.color = Color.red;

        FindObjectOfType<AudioManager>().PlayLoop("Gigantism");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.health += ((enemy.getMaxhealth() / 1000f) * 1.5f);  //The += number should be equal to boss maxhealth/1000f * 1.5f
        gf.transform.localScale += new Vector3(0.01f, 0.01f, 0f);

        if (gf.transform.localScale.x > 7f)
        {
            gf.transform.localScale = new Vector3(7f, 7f, 0f);
        }

        if (enemy.health > enemy.getMaxhealth())
        {
            enemy.health = enemy.getMaxhealth();
        }

        if (enemy.health == enemy.getMaxhealth() && gf.transform.localScale.x == 7f)
        {
            animator.SetTrigger("Phase3");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManager>().StopLoop("Gigantism");
        animator.ResetTrigger("Phase3");
    }
}
