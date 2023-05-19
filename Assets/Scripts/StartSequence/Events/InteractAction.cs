using Interactables;
using UnityEngine;

namespace Events.Actions
{
    [CreateAssetMenu(fileName = "InteractAction", menuName = "Data/Actions/InteractAction")]
    public class InteractAction : AEventAction
    {
        private EventResponder m_responder = null;
        private IInteractable m_interactable = null;

        private bool m_hasInteracted = false;

        public override void Reset()
        {
            m_hasInteracted = false;
        }

        public override void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data)
        {
            m_responder = _responder;
            m_interactable = _context.GetComponent<IInteractable>();

            m_responder.UnbindFromInteractable(m_interactable);

            m_interactable.OnInteract += InteractionCompleted;
        }

        private void InteractionCompleted(IInteractable _interactable)
        {
            if (m_hasInteracted)
                return;

            _interactable.InteractionSuccesful();
            m_hasInteracted = true;
        }

        public override bool UpdateAction()
        {
            return m_hasInteracted;
        }

        public override void EndAction()
        {
            m_interactable.OnInteract -= InteractionCompleted;

            m_responder.BindToInteractable(m_interactable);

            m_responder = null;
            m_interactable = null;
            m_hasInteracted = false;
        }
    }
}