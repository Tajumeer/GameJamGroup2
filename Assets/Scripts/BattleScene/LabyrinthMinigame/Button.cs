using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject laserGate;
    [SerializeField] GameObject goalGate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Electron"))
        {
            laserGate.SetActive(false);
            goalGate.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
