using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGoal : MonoBehaviour
{
    public bool labyrinthIsWon = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Electron"))
        {
            labyrinthIsWon = true;
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
