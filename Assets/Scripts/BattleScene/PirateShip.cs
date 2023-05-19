using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PirateShip : BaseInteractable
{
    bool isDestroyed = false;
    public override bool Interact()
    {
        if(isDestroyed)
        {
            SceneManager.LoadScene("repairScene");
        }
        return true;
    }

    public override bool HoverStart()
    {
        m_audioSource.clip = DataAsset.HoverSound;
        m_audioSource.Play();
        return true;
    }

    public override bool Hover()
    {
        return true;
    }
}
