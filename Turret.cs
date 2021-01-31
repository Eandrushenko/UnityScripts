using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private float elapsed = 0f;
    private bool canShoot = false;

    public float firerate;

    public GameObject Bullet;
    public Transform Firepoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        elapsed += Time.deltaTime;
        if (canShoot)
        {
            Shoot();
            elapsed = elapsed % 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.gameObject.GetComponent<Player>();
        if (player != null)
        {
            canShoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Player player = col.gameObject.GetComponent<Player>();
        if (player != null)
        {
            canShoot = false;
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
    }
}
