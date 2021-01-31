using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour {

    public Animator animator;
	
	// Update is called once per frame
	void Update ()
    {
        if (animator != null)
        {
            if (animator.GetBool("Found"))
            {
                Close();
            }
        }
	}

    void Close()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-138.18f, 5.465f, 0f), 1f);
    }
}
