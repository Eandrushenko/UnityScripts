using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public GameObject face;
    public Sprite[] faces;

    public RectTransform indicator;

    public bool[] Active;

    public Transform ring;

    public float timeleft = 30f;
    public int heals = 3;
    public int rages = 1;

    private float healrate = 10f;

    private bool isPaused;

    void Activate(int j)
    {
        for (int i = 0; i < Active.Length; i++)
        {
            Active[i] = false;
        }
        Active[j] = true;
    }


    void Ability1()
    {
        face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[0];
        indicator.anchoredPosition = new Vector2(-450f, 40f);

        Activate(0);
    }

    void Ability2()
    {
        Player health = GetComponent<Player>();
        if (heals > 0 && (health.currentHealth < health.maxHealth))
        {
            face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[1];
            indicator.anchoredPosition = new Vector2(-310f, 40f);
            heals -= 1;
            FindObjectOfType<AudioManager>().PlayLoop("Heal");

            Activate(1);
        }
    }

    void Ability3()
    {
        face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[2];
        indicator.anchoredPosition = new Vector2(-160f, 40f);
        Activate(2);
    }

    void Ability4()
    {
        if (timeleft > 0)
        {
            face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[3];
            indicator.anchoredPosition = new Vector2(0f, 40f);

            PlayerController jump = GetComponent<PlayerController>();
            PlayerMovement speed = GetComponent<PlayerMovement>();
            speed.runSpeed = 80f;
            jump.m_JumpForce = 2000f;

            FindObjectOfType<AudioManager>().Play("Surprise");

            Activate(3);
        }
    }

    void Ability5()
    {
        Player blocks = GetComponent<Player>();
        if (blocks.shields > 0)
        {
            face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[4];
            indicator.anchoredPosition = new Vector2(-450f, -30f);
            FindObjectOfType<AudioManager>().Play("ShieldOn");

            Activate(4);
        }
    }

    void Ability6()
    {
        face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[5];
        indicator.anchoredPosition = new Vector2(-310f, -30f);

        Activate(5);
    }

    void Ability7()
    {
        face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[6];
        indicator.anchoredPosition = new Vector2(-160f, -30f);

        Activate(6);
    }

    void Ability8()
    {
        if (rages > 0)
        {
            face.gameObject.GetComponent<SpriteRenderer>().sprite = faces[7];
            indicator.anchoredPosition = new Vector2(0f, -30f);
            Instantiate(ring, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Rage");
            rages -= 1;

            Activate(7);
        }
    }

    void Abilities()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Ability1();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Ability2();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Ability3();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Ability4();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            Ability5();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            Ability6();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            Ability7();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            Ability8();
        }
    }

	// Use this for initialization
	void Start ()
    {
        timeleft = GameControl.control.Time;
        rages = GameControl.control.Bursts;
        heals = GameControl.control.Heals;

        healrate = GameControl.control.Health;
        healrate /= 10f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        isPaused = FindObjectOfType<Overseer>().isPaused;
        if (!isPaused)
        {
            Abilities();
            defaultState();
            abilityClock();
            if (Active[1])
            {
                Player health = GetComponent<Player>();
                if (health.currentHealth < health.maxHealth)
                {
                    health.currentHealth = health.currentHealth + Time.deltaTime * healrate;
                    FindObjectOfType<AudioManager>().setPitch("Heal", (health.currentHealth / health.maxHealth));
                }
                else
                {
                    Active[1] = false;
                }
            }
            else
            {
                FindObjectOfType<AudioManager>().StopLoop("Heal");
            }
        }
    }

    void defaultState()
    {
        if (!Active[0] && !Active[1] && !Active[2] && !Active[3] && !Active[4] && !Active[5] && !Active[6] && !Active[7])
        {
            Ability1();
        }
        if (!Active[3])
        {
            PlayerController jump = GetComponent<PlayerController>();
            PlayerMovement speed = GetComponent<PlayerMovement>();
            speed.runSpeed = 40f;
            jump.m_JumpForce = 1500f;
        }
    }

    void abilityClock()
    {
        if (Active[3])
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0)
            {
                timeleft = 0f;
                Active[3] = false;
            }
        }
    }
}
