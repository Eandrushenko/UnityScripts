using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Enemy enemy;
	
	// Update is called once per frame
	void Update ()
    {
		if (enemy.health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
