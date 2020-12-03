using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Transform player;
    public float sightRange = 1f;
    public LayerMask layermask;
    public EnemyPivot pivot;

    public bool PlayerDetection()
    {
        bool found = false;
        if (player != null)
        {
            Enemy damagecheck = GetComponent<Enemy>();

            Vector3 origin = transform.position;

            Debug.DrawRay(origin, (player.position - origin) * sightRange, Color.red);

            if (Vector3.Distance(transform.position, player.position) < sightRange)
            {
                RaycastHit2D hit = Physics2D.Raycast(origin, (player.position - origin), sightRange, layermask);
                if (hit)
                {
                    if (hit.transform == player || hit.transform == GetComponent<Bullet>())
                    {
                        found = true;
                        pivot.isAggro = true;
                    }
                }
            }
            if (damagecheck.health < damagecheck.getMaxhealth())
            {
                found = true;
                pivot.isAggro = true;
            }
        }
        return found;
    }
}
