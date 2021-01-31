using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour {

    public GameObject Bullet;

    public Enemy enemy;

    public Transform[] pivot;

    public float fireRate = 1f;
    private float nextFire = 0f;

    // Update is called once per frame
    void Update ()
    {
        Shoot();
        if (!enemy.isAlive)
        {
            Destroy(gameObject);
        }
	}

    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(Bullet, pivot[0].position, pivot[0].rotation);
            Instantiate(Bullet, pivot[1].position, pivot[1].rotation);
            Instantiate(Bullet, pivot[2].position, pivot[2].rotation);
            Instantiate(Bullet, pivot[3].position, pivot[3].rotation);
            Instantiate(Bullet, pivot[4].position, pivot[4].rotation);
            nextFire = Time.time + fireRate;
        }
    }


}
