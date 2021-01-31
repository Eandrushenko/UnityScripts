using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_Giant : MonoBehaviour {

    private Transform player;
    private Guardian_Flight gf;
    private Colossus_Guardian cg;

    private bool isPaused;

    [HideInInspector]
    public int Attack;

    public LineRenderer StandardLine;

    public GameObject rocket;
    public GameObject GiantArm1Shot;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
        gf = GetComponent<Guardian_Flight>();
        cg = GetComponent<Colossus_Guardian>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gf.FinalPhase)
        {
            Attack = Mathf.FloorToInt(Random.Range(1, 3.99f));

            Sapper();
        }
		
	}


    public void Sapper()
    {
        isPaused = FindObjectOfType<Overseer>().isPaused;
        if (player != null && !isPaused && player.position.x < 45f)
        {
            RaycastHit2D hitinfo = Physics2D.Raycast(cg.LaserBeltFirepoint.position, (player.position - cg.LaserBeltFirepoint.position), 1000f, cg.layermask);
            if (hitinfo)
            {
                Player target = hitinfo.transform.GetComponent<Player>();
                if (target != null)
                {
                    StandardLine.enabled = true;
                    target.TakeDamage(1f);
                    if (!FindObjectOfType<AudioManager>().isPlaying("GiantLaserBeam"))
                    {
                        FindObjectOfType<AudioManager>().Play("GiantLaserBeam");
                    }
                }

                StandardLine.SetPosition(0, cg.LaserBeltFirepoint.position);
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

    public void FireRocket()
    {
        FindObjectOfType<AudioManager>().Play("Launch");
        Instantiate(rocket, cg.ShoulderFirepoint.transform.position, cg.ShoulderFirepoint.transform.rotation);
    }

    public void Spawn()
    {
        if (player != null)
        {
            Vector3 RandomPosition = new Vector3(Random.Range(50f, 100f), Random.Range(33f, 40f), 0f);
            cg.SummonSpot.position = RandomPosition;
            StartCoroutine(Zap());
        }
    }

    public IEnumerator Zap()
    {
        cg.StandardLine2.SetPosition(0, cg.ShoulderFirepoint.position);
        cg.StandardLine2.SetPosition(1, cg.SummonSpot.position);
        cg.StandardLine2.enabled = true;

        Instantiate(cg.Ghost, cg.SummonSpot.position, cg.SummonSpot.rotation);

        FindObjectOfType<AudioManager>().Play("Dark_Teleport");

        yield return new WaitForSeconds(0.5f);

        cg.StandardLine2.enabled = false;
    }

    public void Launch()
    {
        FindObjectOfType<AudioManager>().Play("GiantArmShot");
        Instantiate(GiantArm1Shot, cg.Arm1.transform.position, cg.Arm1.transform.rotation);
        cg.alpha = 0f;
        cg.ARM.color = new Color(255, 255, 255, cg.alpha);
    }

}
