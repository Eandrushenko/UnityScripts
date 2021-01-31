using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_Ghost : MonoBehaviour {

    public Transform Firepoint;

    public GameObject Bullet;

    public float fireRate = 0.2f;
    private float nextFire = 0f;

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            Fire();
            nextFire = Time.time + fireRate;
        }
    }

    private void Fire()
    {
        FindObjectOfType<AudioManager>().Play("ScannerShot");
        Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
    }
}
