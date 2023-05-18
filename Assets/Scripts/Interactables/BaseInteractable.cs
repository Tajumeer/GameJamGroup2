using UI;
using UnityEngine;

namespace Interactables
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class BaseInteractable : MonoBehaviour, IInteractable
    {

        public event System.Action<IInteractable> OnInteract
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

        public event System.Action<IInteractable> OnHoverStart
        {
            add
            {
                m_onHoverStart -= value;
                m_onHoverStart += value;
            }
            remove
            {
                m_onHoverStart -= value;
            }
        }

        public event System.Action<IInteractable> OnHoverEnd
        {
            add
            {
                m_onHoverEnd -= value;
                m_onHoverEnd += value;
            }
            remove
            {
                m_onHoverEnd -= value;
            }
        }

        public event System.Action<IInteractable> OnHover
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

        public string Name => m_dataAsset.ObjectName;

        public bool IsHovered { get => m_isHovered; set => m_isHovered = value; }

        public GameObject Owner => this.gameObject;

        [SerializeField]
        protected InteractableAsset m_dataAsset = null;

        protected AudioSource m_audioSource = null;

        protected event System.Action<IInteractable> m_onInteract;
        protected event System.Action<IInteractable> m_onHoverStart;
        protected event System.Action<IInteractable> m_onHover;
        protected event System.Action<IInteractable> m_onHoverEnd;

        protected bool m_isHovered = false;
        protected bool m_wasHoveredLastFrame = false;

        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (IsHovered && !m_wasHoveredLastFrame)
                HoverStart();
            if (!IsHovered && m_wasHoveredLastFrame)
                HoverEnd();
            if (IsHovered && m_wasHoveredLastFrame)
                Hover();

            m_wasHoveredLastFrame = IsHovered;
            IsHovered = false;
        }

        public bool Interact()
        {
            m_onInteract?.Invoke(this);

            return true;
        }

        public bool Hover()
        {
            m_onHover?.Invoke(this);

            return true;
        }

        public bool HoverStart()
        {
            m_audioSource.clip = m_dataAsset.HoverSound;
            m_audioSource.Play();

            m_onHoverStart?.Invoke(this);

            Subtitles.Instance.DisplayText(m_dataAsset.ObjectName);

            return true;
        }

        public void HoverEnd()
        {
            m_onHoverEnd?.Invoke(this);
        }

        public bool InteractionSuccesful()
        {
            m_audioSource.clip = m_dataAsset.SuccesfulInteractSound.AudioClip;
            m_audioSource.Play();

            Subtitles.Instance.DisplayText(m_dataAsset.SuccesfulInteractSound.Text);

            return true;
        }

        public bool InteractionWrong()
        {
            m_audioSource.clip = m_dataAsset.WrongInteractSound.AudioClip;
            m_audioSource.Play();

            Subtitles.Instance.DisplayText(m_dataAsset.WrongInteractSound.Text);

            return true;
        }
    }
}
