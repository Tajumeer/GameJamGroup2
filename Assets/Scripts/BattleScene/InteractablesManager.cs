using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractablesManager : MonoBehaviour
{
    public static InteractablesManager interactablesManager;
    public static bool powerIsConverted = false;
    public static bool windowIsEjected = false;
    public static bool toyAmmoIsCollected = false;
    public static BaseInteractable currInteractable;

    
    void Awake()
    {
        if (interactablesManager != null)
            GameObject.Destroy(interactablesManager);
        else
            interactablesManager = this;

        DontDestroyOnLoad(this);
    }

    public static void DestroyPirateShip()
    {
        SceneManager.LoadScene("repairShip");
    }
}
