using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PirateShip : BaseInteractable
{
    public override bool Interact()
    {
        if (InteractablesManager.currInteractable == null)
        {
            InteractablesManager.currInteractable = this;
            Debug.Log(InteractablesManager.currInteractable);
        }
        else if (InteractablesManager.currInteractable.DataAsset.ObjectName == "Watergun" && 
                 InteractablesManager.windowIsEjected &&
                 InteractablesManager.toyAmmoIsCollected)
        {
            InteractionSuccessful();
        }
        else
        {
            InteractionWrong();
            InteractablesManager.currInteractable = null;
        }
        return true;
    }

    public override bool HoverStart()
    {
        m_audioSource.clip = DataAsset.HoverSound;
        m_audioSource.Play();

        m_hoverTextDisplay.RequestUpdateHoverText(m_dataAsset.ObjectName + "\n" + m_dataAsset.Description);
        return true;
    }

    public override bool Hover()
    {
        return true;
    }

    public void Destroy()
    {
        SceneManager.LoadScene("repairScene");
    }

    public override bool InteractionSuccessful()
    {
        InteractablesManager.DestroyPirateShip();
        return true;
    }
}
