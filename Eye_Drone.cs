using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye_Drone : MonoBehaviour {

    private Transform player;

    private bool isPaused;

    public Transform firepoint;

    public LineRenderer StandardLine;
    public LayerMask layermask;

    private Enemy enemy;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
    }


    void Update()
    {
        if (!enemy.isAlive)
        {
            StandardLine.enabled = false;
        }
    }

    public void Sapper()
    {
        isPaused = FindObjectOfType<Overseer>().isPaused;
        if (player != null && !isPaused)
        {
            RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, (player.position - firepoint.position), 10f, layermask);
            if (hitinfo)
            {
                Player target = hitinfo.transform.GetComponent<Player>();
                if (target != null)
                {
                    StandardLine.enabled = true;
                    target.TakeDamage(1f);
                    if (!FindObjectOfType<AudioManager>().isPlaying("LaserBeam"))
                    {
                        FindObjectOfType<AudioManager>().Play("LaserBeam");
                    }
                }

                StandardLine.SetPosition(0, firepoint.position);
                StandardLine.SetPosition(1, hitinfo.transform.position);
            }
            else
            {
                StandardLine.enabled = false;
            }
        }
        else
        {
            StandardLine.enabled = false;
        }
    }
}
