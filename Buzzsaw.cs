using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzsaw : MonoBehaviour {

    private float rotationZ = 0f;

    public Vector2[] destinations;
    public float speed = 0;

    private int i = 0;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rotationZ += 2f;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ >= 359f)
        {
            rotationZ = 0f;
        }

        MoveToPoints();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        Player player = collision.gameObject.GetComponent<Player>();
        if (enemy != null)
        {
            enemy.TakeDamage(enemy.getMaxhealth());
        }
        else if (player != null)
        {
            player.TakeDamage(player.maxHealth);
        }
    }

    private void MoveToPoints()
    {
        if (destinations.Length > 1)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(destinations[i].x, destinations[i].y), step);
            if (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) == destinations[i])
            {
                i += 1;
                if (i >= destinations.Length)
                {
                    i = 0;
                }
            }
        }
    }


}
