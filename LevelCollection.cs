using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollection : MonoBehaviour
{

    public GameObject[] Levels;

	// Use this for initialization
	void Start ()
    {
        int i = 0;
        while (i < GameControl.control.LP)
        {
            Levels[i].SetActive(true);
            i++;
        }
	}
}
