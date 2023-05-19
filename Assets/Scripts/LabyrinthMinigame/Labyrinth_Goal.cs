using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth_Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Electron"))
        {

        }
    }
}
