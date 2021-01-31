using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSpawner : MonoBehaviour {

    public Vector3 Spawnpoint;

    public GameObject worker;

    public float spawnRate = 2f;
    private float nextSpawn = 0f;
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextSpawn)
        {
            Instantiate(worker, Spawnpoint, worker.transform.rotation);
            nextSpawn = Time.time + spawnRate;
        }
    }
}
