using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour
{
    public GameObject CreditRoll;

    public float RollSpeed = 0f;
    private float startposition = 0f;

    private bool startCredits = false;

    private bool once = true;

    public GameObject backbutton;
    // Use this for initialization
    void Start()
    {
        startposition = CreditRoll.transform.position.y;
        FindObjectOfType<AudioManager>().PlayLoop("Birds");
    }

    // Update is called once per frame
    void Update()
    {
        if (startCredits)
        {
            startposition += RollSpeed;
            CreditRoll.transform.position = new Vector3(CreditRoll.transform.position.x, startposition, 0f);
        }
        if (CreditRoll.transform.position.y >= 4600f)
        {
            startCredits = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hero player = collision.gameObject.GetComponent<Hero>();
        if (player != null)
        {
            FindObjectOfType<AudioManager>().setVolume("Birds", 0f);
            if (once)
            {
                FindObjectOfType<AudioManager>().Play("Song1");
                backbutton.SetActive(true);
                startCredits = true;
                once = false;
            }
        }
    }
}
