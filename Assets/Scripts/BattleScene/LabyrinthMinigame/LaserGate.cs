using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class LaserGate : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    bool isReady = true;
    private void Update()
    {
        ActivateLasers();
    }
    void ActivateLasers()
    {
        if(!isReady)
        {
            return;
        }


        foreach (var laser in lasers)
        {
            if (laser.active)
                laser.SetActive(false);
            else if (!laser.active)
                laser.SetActive(true);
        }
        StartCoroutine(ActivationTimer());
        return;

    }
    public IEnumerator ActivationTimer()
    {
        isReady = false;
        yield return new WaitForSeconds(1);
        isReady = true;
    }

}

