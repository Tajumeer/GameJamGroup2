using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCactus : BaseInteractable
{
    public override bool HoverStart()
    {
        m_audioSource.clip = DataAsset.HoverSound;
        m_audioSource.Play();
        return true;
    }

    public override bool Interact()
    {
        if(InteractablesManager.currInteractable == null)
        {
            InteractablesManager.currInteractable = this;
            Debug.Log(InteractablesManager.currInteractable);
        }
        else if(InteractablesManager.currInteractable.DataAsset.ObjectName == "Toy-Gun")
        {
            InteractionSuccessful();
        }
        else
        {
            InteractionWrong();
            InteractablesManager.currInteractable = null;
        }    
        InteractionWrong();
        return true;
    }

    public override bool InteractionWrong()
    {
        m_audioSource.clip = DataAsset.WrongInteractSound.AudioClip;
        m_audioSource.Play();

        m_interactionTextDisplay.UpdateInteractionText(DataAsset.WrongInteractSound.Text);
        return true;
    }
}
