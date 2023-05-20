using Interactables;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Torpedorohr : BaseInteractable
{
    public override bool HoverStart()
    {
        m_audioSource.clip = DataAsset.HoverSound;
        m_audioSource.Play();

        m_hoverTextDisplay.RequestUpdateHoverText(m_dataAsset.ObjectName + "\n" + m_dataAsset.Description);
        return true;
    }

    public override bool Interact()
    {
        if (InteractablesManager.currInteractable == null)
        {
            InteractablesManager.currInteractable = this;
            Debug.Log(InteractablesManager.currInteractable);
        }
        else if (InteractablesManager.currInteractable.DataAsset.ObjectName == "OfficeCabinet")
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

    public override bool InteractionWrong()
    {
        m_audioSource.clip = DataAsset.WrongInteractSound.AudioClip;
        m_audioSource.Play();

        m_interactionTextDisplay.UpdateInteractionText(DataAsset.WrongInteractSound.Text);
        return true;
    }

    public override bool InteractionSuccessful()
    {
        m_audioSource.clip = DataAsset.SuccesfulInteractSound.AudioClip;
        m_audioSource.Play();
        InteractablesManager.toyAmmoIsCollected = true;
        Debug.Log(InteractablesManager.toyAmmoIsCollected);

        m_interactionTextDisplay.UpdateInteractionText(DataAsset.SuccesfulInteractSound.Text);
        return true;
    }
}
