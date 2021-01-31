using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_Dead : StateMachineBehaviour {

    Mothership mothership;
    Rigidbody2D rb;

    public float ExplodeRate;
    private float nextExplode = 0f;

    int counter = 0;

    bool canRun = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mothership = animator.GetComponent<Mothership>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoExplode();
        if (counter == 6)
        {
            rb.gravityScale = 1f;
            rb.constraints = RigidbodyConstraints2D.None;
            if (canRun)
            {
                mothership.runGoAway();
                canRun = false;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void DoExplode()
    {
        if (Time.time > nextExplode)
        {
            if (counter <= 5)
            {
                mothership.Explode(counter);
                counter++;
                nextExplode = Time.time + ExplodeRate;
            }
        }
    }
}
