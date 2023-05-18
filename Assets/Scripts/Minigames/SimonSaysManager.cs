using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames
{
    public class SimonSaysManager : MonoBehaviour, IMinigame
    {
        public GameObject Owner => this.gameObject;

        public event Action<IMinigame> OnMinigameStarted
        {
            add
            {
                m_onMinigameStarted -= value;
                m_onMinigameStarted += value;
            }
            remove
            {
                m_onMinigameStarted -= value;
            }
        }

        public event Action<IMinigame> OnMinigameEnded
        {
            add
            {
                m_onMinigameEnded -= value;
                m_onMinigameEnded += value;
            }
            remove
            {
                m_onMinigameEnded -= value;
            }
        }

        private event Action<IMinigame> m_onMinigameStarted;
        private event Action<IMinigame> m_onMinigameEnded;

        public bool EndMinigame()
        {
            throw new NotImplementedException();
        }

        public bool StartMinigame()
        {
            throw new NotImplementedException();
        }
    }

}