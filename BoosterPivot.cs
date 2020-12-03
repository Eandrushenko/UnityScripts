using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPivot : MonoBehaviour {

    public EnemyPivot EP;

	// Use this for initialization
	
	// Update is called once per frame
	void Update ()
    {
        if (EP.isAggro)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
	}
}
