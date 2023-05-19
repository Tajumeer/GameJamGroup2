using StartSequence.UI;
using System.Linq;
using UI;
using UnityEngine;

namespace Interactables
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody2D))]
    public class BaseInteractable : MonoBehaviour, IInteractable, IHoverable, IInteractionDataUser
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

        public bool IsHovered { get => m_isHovered; set => m_isHovered = value; }

        public GameObject Owner => this.gameObject;

        public InteractableAsset DataAsset { get => m_dataAsset; set => m_dataAsset = value; }

        [SerializeField]
        protected InteractableAsset m_dataAsset = null;

        protected AudioSource m_audioSource = null;

        protected event System.Action<IInteractable> m_onInteract;
        protected event System.Action<IInteractable> m_onHoverStart;
        protected event System.Action<IInteractable> m_onHover;
        protected event System.Action<IInteractable> m_onHoverEnd;

        protected bool m_isHovered = false;
        protected bool m_wasHoveredLastFrame = false;

        protected IHoverTextDisplay m_hoverTextDisplay;
        protected IInteractionTextDisplay m_interactionTextDisplay;

        private void OnValidate()
        {
            if (DataAsset == null)
                return;

            this.gameObject.name = DataAsset.ObjectName;
        }

        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();

            m_hoverTextDisplay = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
                                                .OfType<IHoverTextDisplay>()
                                                .FirstOrDefault();

            m_interactionTextDisplay = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
                                                .OfType<IInteractionTextDisplay>()
                                                .FirstOrDefault();
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

        public virtual bool Interact()
        {
            m_onInteract?.Invoke(this);

            return true;
        }

        public virtual bool Hover()
        {
            m_onHover?.Invoke(this);

            return true;
        }

        public virtual bool HoverStart()
        {
            m_audioSource.clip = DataAsset.HoverSound;
            m_audioSource.Play();

            m_onHoverStart?.Invoke(this);

            m_hoverTextDisplay.RequestUpdateHoverText(m_dataAsset.ObjectName + "\n" + m_dataAsset.Description);

            return true;
        }

        public virtual void HoverEnd()
        {
            m_onHoverEnd?.Invoke(this);
        
            m_hoverTextDisplay.CancelUpdateHoverTextRequest(m_dataAsset.ObjectName + "\n" + m_dataAsset.Description);
        }

        public virtual bool InteractionSuccessful()
        {
            m_audioSource.clip = DataAsset.SuccesfulInteractSound.AudioClip;
            m_audioSource.Play();

            m_interactionTextDisplay.UpdateInteractionText(DataAsset.SuccesfulInteractSound.Text);

            return true;
        }

        public virtual bool InteractionWrong()
        {
            m_audioSource.clip = DataAsset.WrongInteractSound.AudioClip;
            m_audioSource.Play();

            m_interactionTextDisplay.UpdateInteractionText(DataAsset.WrongInteractSound.Text);

            return true;
        }
    }
}
