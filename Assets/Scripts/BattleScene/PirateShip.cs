using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : BaseInteractable
{
    public override bool Interact()
    {

        return true;
    }

    public override bool HoverStart()
    {
        m_audioSource.clip = DataAsset.SuccesfulInteractSound.AudioClip;
        m_audioSource.Play();
        return true;
    }

    public override bool Hover()
    {
        return true;
    }
}
