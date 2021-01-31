using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierDrone : MonoBehaviour {

    public Vector2[] destinations;

    public float speed;

    private int i = 0;

    private bool beginrun = false;
    private bool FacingRight = true;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToPoints();
        LookAtDestination();
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
            beginrun = true;
        }
    }

    private void MoveToPoints()
    {
        if (destinations.Length >= 1 && beginrun)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(destinations[i].x, destinations[i].y), step);
            if (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) == destinations[i])
            {
                i += 1;
                if (i >= destinations.Length)
                {
                    i = destinations.Length - 1;
                }
            }
        }
    }


    public void LookAtDestination()
    {
        if ((transform.position.x > destinations[i].x) && FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            FacingRight = false;
        }
        else if ((transform.position.x < destinations[i].x) && !FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            FacingRight = true;
        }
    }
}
