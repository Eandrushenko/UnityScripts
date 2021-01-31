using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guardian_Flight : MonoBehaviour {

    private Transform target;

    [HideInInspector]
    public bool flight = false;

    public Vector3 OffSet = new Vector3(1f, 2f, 0f);

    private Vector3 DropPoint = new Vector3(20f, 35f , 0f);

    public Image HealthBar;

    private Enemy enemy;

    [HideInInspector]
    public bool FinalPhase = false;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
        flight = false;
    }

    void FixedUpdate()
    {
        if (flight && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + OffSet, 0.1f);
        }

        if ((enemy.health <= enemy.getMaxhealth() / 10) && !FinalPhase)
        {
            enemy.isInvulernable = true;
        }
        else if (FinalPhase)
        {
            enemy.isInvulernable = false;
        }
    }

    public void GOTO_DropPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, DropPoint, 0.1f);
    }

    public bool CheckPoint()
    {
        bool result = false;

        if (transform.position == DropPoint)
        {
            result = true;
        }

        return result;
    }
}
