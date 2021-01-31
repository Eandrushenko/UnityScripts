using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotpad : MonoBehaviour {

    public Renderer[] hotspot;

    public Transform[] Firepoint;

    public GameObject Bullet;

    private float elapsed = 0f;

    private bool isCoroutineExecuting = false;

    public bool[] randoms;

    private int i = 0;
    private float time1 = 4f;
    private float time2 = 2f;

    public GameObject door;

    private bool once = true;

    // Use this for initialization
    void Start ()
    {
        Reset();
    }

    void FixedUpdate()
    {
        if (i <= 40)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= time1)
            {
                elapsed = elapsed % 1f;
                StartCoroutine(ExecuteAfterTime(time2));
                i++;
            }
        }
        else if (once)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= time1)
            {
                green();
                door.SetActive(false);
                once = false;
            }
        }

        if (i >= 30)
        {
            time1 = 1.5f;
            time2 = 0.5f;
        }
        else if (i >= 20)
        {
            time1 = 2f;
            time2 = 1f;
        }
        else if (i >= 10)
        {
            time1 = 3f;
            time2 = 1.5f;
        }

    }

    private void Reset()
    {
        hotspot[0].material.color = Color.black;
        hotspot[1].material.color = Color.black;
        hotspot[2].material.color = Color.black;
        hotspot[3].material.color = Color.black;
        hotspot[4].material.color = Color.black;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        //hotspot[0].material.color = Color.red;
        randomizer();
        red();

        yield return new WaitForSeconds(time);

        isCoroutineExecuting = false;
        // Code to execute after the delay
        shoot();
        Reset();
    }

    private void randomizer()
    {
        randoms[0] = (Random.value > 0.5f);
        randoms[1] = (Random.value > 0.5f);
        randoms[2] = (Random.value > 0.5f);
        randoms[3] = (Random.value > 0.5f);
        randoms[4] = (Random.value > 0.5f);
        if (randoms[0] == true && randoms[1] == true && randoms[2] == true && randoms[3] == true && randoms[4] == true)
        {
            randoms[0] = false;
        }
    }

    private void red()
    {
        if (randoms[0] == true)
        {
            hotspot[0].material.color = Color.red;
        }
        if (randoms[1] == true)
        {
            hotspot[1].material.color = Color.red;
        }
        if (randoms[2] == true)
        {
            hotspot[2].material.color = Color.red;
        }
        if (randoms[3] == true)
        {
            hotspot[3].material.color = Color.red;
        }
        if (randoms[4] == true)
        {
            hotspot[4].material.color = Color.red;
        }
    }

    private void shoot()
    {
        if (randoms[0] == true || randoms[1] == true || randoms[2] == true || randoms[3] == true || randoms[4] == true)
        {
            FindObjectOfType<AudioManager>().Play("Woosh");
        }


        if (randoms[0] == true)
        {
            Instantiate(Bullet, Firepoint[0].position, Quaternion.identity);
        }
        if (randoms[1] == true)
        {
            Instantiate(Bullet, Firepoint[1].position, Quaternion.identity);
        }
        if (randoms[2] == true)
        {
            Instantiate(Bullet, Firepoint[2].position, Quaternion.identity);
        }
        if (randoms[3] == true)
        {
            Instantiate(Bullet, Firepoint[3].position, Quaternion.identity);
        }
        if (randoms[4] == true)
        {
            Instantiate(Bullet, Firepoint[4].position, Quaternion.identity);
        }
    }

    private void green()
    {
        hotspot[0].material.color = Color.green;
        hotspot[1].material.color = Color.green;
        hotspot[2].material.color = Color.green;
        hotspot[3].material.color = Color.green;
        hotspot[4].material.color = Color.green;

        FindObjectOfType<AudioManager>().Play("Success");
    }
}
