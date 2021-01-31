using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBot : MonoBehaviour
{

    public Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;

    [Range(0, 1)]
    [SerializeField]
    private float m_MovementSmoothing = .05f;

    private bool m_FacingRight;

    public float runSpeed = 40f;
    private float horizontalMove = 0f;

    public float range;
    public GameObject Explode;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMove = -1 * runSpeed;
        Move(horizontalMove * Time.fixedDeltaTime);
        Limit();
    }

    private void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    private void Limit()
    {
        if (transform.position.x < range)
        {
            Instantiate(Explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
