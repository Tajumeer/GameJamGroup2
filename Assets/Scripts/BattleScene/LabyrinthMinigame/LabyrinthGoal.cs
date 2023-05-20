using Events.Actions;
using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Electron"))
        {
            InteractablesManager.powerIsConverted = true;
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
