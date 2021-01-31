using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSGrab : MonoBehaviour {

    public Transform player;
    public GameObject MSTeleport;

    public Vector2 Location;

    private bool onlyonce = true;

    public Enemy enemy;
	
	// Update is called once per frame
	void Update ()
    {
		if ((!enemy.isAlive || enemy.health <= 0f) && onlyonce)
        {
            onlyonce = false;
            StartCoroutine(moveplayer());
        }
	}

    IEnumerator moveplayer()
    {
        yield return new WaitForSeconds(3f);
        FindObjectOfType<AudioManager>().Play("Dark_Teleport");
        Instantiate(MSTeleport, transform.position, transform.rotation);
        player.transform.position = new Vector3(Location.x, Location.y, transform.position.z);
        Instantiate(MSTeleport, transform.position, transform.rotation);
    }
}
