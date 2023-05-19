using UnityEngine;

namespace Minigames
{
    public interface IMinigame
    {
        public GameObject Owner { get; }

        public event System.Action<IMinigame> OnMinigameStarted;
        public event System.Action<IMinigame> OnMinigameEnded;

        public bool StartMinigame();
        public bool EndMinigame();
    }
}