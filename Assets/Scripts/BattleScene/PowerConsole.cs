using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConsole : BaseInteractable
{
    [SerializeField] GameObject labyrinth;
    public override bool Interact()
    {
        if(labyrinth.active == false && !InteractablesManager.powerIsConverted)
        {
            InteractionSuccessful();
            labyrinth.SetActive(true);
        }
        else if(labyrinth.active == false && InteractablesManager.powerIsConverted)
        {
            InteractionWrong();
        }
        else
        {
            labyrinth.SetActive(false);
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

    public override bool InteractionSuccessful()
    {
        m_audioSource.clip = DataAsset.SuccesfulInteractSound.AudioClip;
        m_audioSource.Play();

        m_interactionTextDisplay.UpdateInteractionText(DataAsset.SuccesfulInteractSound.Text);

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
