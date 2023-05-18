using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(AudioSource))]
    [DisallowMultipleComponent]
    public class BaseInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        protected InteractableAsset m_dataAsset = null;

        public event System.Action<BaseInteractable> OnInteract
        {
            add
            {
                m_onInteract -= value;
                m_onInteract += value;
            }
            remove
            {
                m_onInteract -= value;
            }
        }

        public event System.Action<BaseInteractable> OnHover
        {
            add
            {
                m_onHover -= value;
                m_onHover += value;
            }
            remove
            {
                m_onHover -= value;
            }
        }

        public string Description => m_dataAsset.Description;

        private AudioSource m_audioSource = null;

        private event System.Action<BaseInteractable> m_onInteract;
        private event System.Action<BaseInteractable> m_onHover;


        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

        public bool Interact()
        {
            m_audioSource.clip = m_dataAsset.InteractSound;
            m_audioSource.Play();

            m_onInteract?.Invoke(this);

            return true;
        }

        public bool Hover()
        {
            m_audioSource.clip = m_dataAsset.HoverSound;
            m_audioSource.Play();

            m_onHover?.Invoke(this);

            return true;
        }
    }
}
