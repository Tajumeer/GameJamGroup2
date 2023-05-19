using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGoal : MonoBehaviour
{
    InteractablesManager interactablesManager;
    public bool labyrinthIsWon = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Electron"))
        {
            interactablesManager.powerIsConverted = true;
            labyrinthIsWon = true;
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
