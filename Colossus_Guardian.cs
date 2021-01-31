using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colossus_Guardian : MonoBehaviour {

    public Animator animator;

    public Animator animatorARM;
    public SpriteRenderer ARM;

    public GameObject bosshealthbar;

    private bool song1 = true;

    Transform player;
    private bool FacingRight = false;

    public EnemyPivot Arm1;
    public EnemyPivot Arm2;
    
    [HideInInspector]
    public int Attack;

    public Transform Arm2FP;
    public GameObject Arm2Shot;

    public GameObject Arm1Shot;

    [HideInInspector]
    public float alpha;

    private bool isPaused;

    public Transform LaserBeltFirepoint;

    public LineRenderer StandardLine;
    public LayerMask layermask;

    private Enemy enemy;

    public LineRenderer StandardLine2;
    public Transform ShoulderFirepoint;
    public GameObject Ghost;
    public Transform SummonSpot;

    private Guardian_Flight gf;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
        gf = GetComponent<Guardian_Flight>();
        enemy = GetComponent<Enemy>();

        DefaultPosition();

        animatorARM.SetBool("Active", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (animator.GetBool("Found"))
        {
            Attack = Mathf.FloorToInt(Random.Range(1, 3.99f));

            bosshealthbar.SetActive(true);

            Music();

            LookAtPlayer();

            if (!gf.FinalPhase)
            {
                Sapper();
            }
        }
        if (alpha < 255f)
        {
            alpha += 0.01f;
            ARM.color = new Color(255, 255, 255, alpha);
        }

        if (!enemy.isAlive)
        {
            StandardLine.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            Spawn();
        }
    }

    void Music()
    {
        if (animator.GetBool("Found") && song1)
        {
            song1 = false;
            FindObjectOfType<AudioManager>().PlayLoop("Song1");
        }
    }

    private void LookAtPlayer()
    {
        if (player != null)
        {
            if ((transform.position.x > player.position.x) && FacingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                FacingRight = false;
            }
            else if ((transform.position.x < player.position.x) && !FacingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                FacingRight = true;
            }
        }
    }

    public void DefaultPosition()
    {
        if (FacingRight)
        {
            Arm1.transform.rotation = Quaternion.Euler(0f, 0f, -40f);
            Arm2.transform.rotation = Quaternion.Euler(0f, 0f, -120f);
        }
        else
        {
            Arm1.transform.rotation = Quaternion.Euler(0f, 180f, -40f);
            Arm2.transform.rotation = Quaternion.Euler(0f, 180f, -120f);
        }
    }

    public void Pulse()
    {
        FindObjectOfType<AudioManager>().Play("PulserShot");
        Instantiate(Arm2Shot, Arm2FP.position, Arm2FP.rotation);
    }

    public void Launch()
    {
        FindObjectOfType<AudioManager>().Play("ArmShot");
        Instantiate(Arm1Shot, Arm1.transform.position, Arm1.transform.rotation);
        alpha = 0f;
        ARM.color = new Color(255, 255, 255, alpha);
    }

    public void Sapper()
    {
        isPaused = FindObjectOfType<Overseer>().isPaused;
        if (player != null && !isPaused)
        {
            RaycastHit2D hitinfo = Physics2D.Raycast(LaserBeltFirepoint.position, (player.position - LaserBeltFirepoint.position), 10f, layermask);
            if (hitinfo)
            {
                Player target = hitinfo.transform.GetComponent<Player>();
                if (target != null)
                {
                    StandardLine.enabled = true;
                    target.TakeDamage(1f);
                    if (!FindObjectOfType<AudioManager>().isPlaying("LaserBeam"))
                    {
                        FindObjectOfType<AudioManager>().Play("LaserBeam");
                    }
                }

                StandardLine.SetPosition(0, LaserBeltFirepoint.position);
                StandardLine.SetPosition(1, hitinfo.transform.position);
            }
            else
            {
                StandardLine.enabled = false;
            }
        }
        else
        {
            StandardLine.enabled = false;
        }
    }

    public void Spawn()
    {
        if (player != null)
        {
            Vector3 Offset = new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 5f), 0f);
            SummonSpot.position = player.position + Offset;
            StartCoroutine(Zap());
        }
    }

    public IEnumerator Zap()
    {
        StandardLine2.SetPosition(0, ShoulderFirepoint.position);
        StandardLine2.SetPosition(1, SummonSpot.position);
        StandardLine2.enabled = true;

        Instantiate(Ghost, SummonSpot.position, SummonSpot.rotation);

        FindObjectOfType<AudioManager>().Play("Dark_Teleport");

        yield return new WaitForSeconds(0.5f);

        StandardLine2.enabled = false;
    }


}
