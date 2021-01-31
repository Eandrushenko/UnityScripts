using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public GameObject laser;

    private bool isCoroutineExecuting = false;

    private float elapsed = 0f;

    public float firerate;
    public float firerate2;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= firerate)
        {
            elapsed = elapsed % 1f;
            StartCoroutine(Zap(firerate2));
        }
    }

    IEnumerator Zap(float delay)
    {

        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        laser.SetActive(true);

        yield return new WaitForSeconds(delay);
        isCoroutineExecuting = false;

        laser.SetActive(false);
    }
}
