using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float Damping = 12f;
    public Transform player;
    public float Height = 0f;
    public float Offset = 0f;

    private Vector3 Center;
    public float ViewDistance = 3f;

    void FixedUpdate()
    {
        if (player)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = ViewDistance;
            Vector3 CursorPosition = Camera.main.ScreenToWorldPoint(mousePos);

            Vector3 PlayerPosition = player.position;

            Center = new Vector3((PlayerPosition.x + CursorPosition.x) / 2, (PlayerPosition.y + CursorPosition.y) / 2, -10f);

            transform.position = Vector3.Lerp(transform.position, Center + new Vector3(0, Height, Offset), Time.fixedDeltaTime * Damping);
        }
    }
}
