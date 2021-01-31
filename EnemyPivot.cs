using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPivot : MonoBehaviour {

    public Transform Enemy;
    private Transform target;
    public bool isAggro = false;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (target != null && isAggro)
        {
            Vector3 difference = target.position - transform.position;
            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            //Adjust Aim based on the direction the enemy is facing
            if (rotationZ < -90 || rotationZ > 90)
            {
                if (Enemy.transform.eulerAngles.y == 0)
                {
                    transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
                }
                else if (Enemy.transform.eulerAngles.y == 180)
                {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
                }
            }
        }
    }
}
