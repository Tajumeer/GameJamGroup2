using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Gate : MonoBehaviour
{
    [SerializeField] Transform start;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Electron")) 
        {
            collision.gameObject.transform.position = start.position;
        }
    }
}
