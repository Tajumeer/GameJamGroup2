using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    public static InteractablesManager interactablesManager;
    public bool powerIsConverted = false;
    public static BaseInteractable currInteractable;

    void Awake()
    {
        if (interactablesManager != null)
            GameObject.Destroy(interactablesManager);
        else
            interactablesManager = this;

        DontDestroyOnLoad(this);
    }
}
