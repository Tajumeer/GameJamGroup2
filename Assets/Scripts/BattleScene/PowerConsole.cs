using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConsole : BaseInteractable
{
    [SerializeField] GameObject labyrinth;
    [SerializeField] LabyrinthGoal labyrinthGoal;
    public override bool Interact()
    {
        if(labyrinth.active == false && !labyrinthGoal.labyrinthIsWon)
        {
            InteractionSuccesful();
            labyrinth.SetActive(true);
        }
        else if(labyrinth.active == false && labyrinthGoal.labyrinthIsWon)
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
        return true;
    }

    public override bool InteractionSuccesful()
    {
        m_audioSource.clip = DataAsset.SuccesfulInteractSound.AudioClip;
        m_audioSource.Play();

        m_interactionTextDisplay.UpdateInteractionText(DataAsset.SuccesfulInteractSound.Text);

        return true;
    }

    public override bool InteractionWrong()
    {
        m_interactionTextDisplay.UpdateInteractionText(DataAsset.WrongInteractSound.Text);
        return true;
    }
}
