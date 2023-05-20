using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectButton : BaseInteractable
{
    [SerializeField] GameObject frontWindow;
    [SerializeField] GameObject containmentField;
    public override bool HoverStart()
    {
        m_audioSource.clip = DataAsset.HoverSound;
        m_audioSource.Play();
        return true;
    }

    public override bool Interact()
    {
        if (!InteractablesManager.powerIsConverted)
            InteractionWrong();
        else
        {
            InteractionSuccessful();
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

        m_interactionTextDisplay.UpdateInteractionText(DataAsset.SuccesfulInteractSound.Text);

        InteractablesManager.windowIsEjected = true;
        frontWindow.SetActive(false);
        containmentField.SetActive(true);

        return base.InteractionSuccessful();
    }
}
