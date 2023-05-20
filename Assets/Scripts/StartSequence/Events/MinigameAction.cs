using Minigames;
using UnityEngine;

namespace Events.Actions
{
    [CreateAssetMenu(fileName = "MinigameAction", menuName = "Data/Actions/MinigameAction")]
    public class MinigameAction : AEventAction
    {
        private IMinigame m_minigame = null;
        private bool m_hasMinigameEnded = false;

        public override void Reset()
        {
            m_hasMinigameEnded = false;
        }

        public override void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data)
        {
            m_minigame = _context.GetComponent<IMinigame>();

            m_minigame.OnMinigameEnded += MinigameEnded;

            m_minigame.StartMinigame();
        }

        private void MinigameEnded(IMinigame _minigame)
        {
            if (m_hasMinigameEnded)
                return;

            m_hasMinigameEnded = true;
        }

        public override bool UpdateAction()
        {
            return m_hasMinigameEnded;
        }

        public override void EndAction()
        {
            m_minigame.OnMinigameEnded -= MinigameEnded;

            m_hasMinigameEnded = false;
            m_minigame = null;
        }
    }
}