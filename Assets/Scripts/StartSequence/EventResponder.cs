using Interactables;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Minigames;
using Sounds;
using UI;
using StartSequence.UI;
using Events.Actions;
using UnityEditor;

namespace Events
{
    [System.Serializable]
    public struct EventEntry
    {
        public AEventAction Action { get => m_action; }
        public GameObject Object { get => m_object; }
        public ScriptableObject Data { get => m_data; }

        [SerializeField]
        private AEventAction m_action;
        [SerializeField]
        private GameObject m_object;
        [SerializeField]
        private ScriptableObject m_data;

        public override string ToString()
        {
            string name = m_object == null ? "no object defined" : m_object.name;
            return $"{m_action.name} with {name}";
        }
    }

    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class EventResponder : MonoBehaviour
    {
        public event System.Action OnAllEventsCleared
        {
            add
            {
                m_onAllEventsCleared -= value;
                m_onAllEventsCleared += value;
            }
            remove
            {
                m_onAllEventsCleared -= value;
            }
        }

        public AudioSource AudioPlayer => m_audioSource;

        [SerializeField]
        private List<EventEntry> m_correctEventOrder = new List<EventEntry>();
        [SerializeField]
        private List<GameObject> m_interactableObjects = new List<GameObject>();
        private AudioSource m_audioSource = null;
        private event System.Action m_onAllEventsCleared;
        private int m_currentIndex;
        private IInteractionTextDisplay m_interactionTextDisplay;

        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();

            foreach (EventEntry eventEntry in m_correctEventOrder)
            {
                eventEntry.Action.Reset();
            }
        }

        private void Start()
        {
            IInteractable[] interactables = m_interactableObjects
                                                        .Select(o => o.GetComponent<IInteractable>())
                                                        .Where(o => o != null)
                                                        .ToArray();


            foreach (IInteractable interactable in interactables)
            {
                BindToInteractable(interactable);
            }

            IHoverable[] hoverables = m_interactableObjects
                                                        .Select(o => o.GetComponent<IHoverable>())
                                                        .Where(o => o != null)
                                                        .ToArray();

            foreach (IHoverable hoverable in hoverables)
            {
                BindToHoverable(hoverable);
            }

            m_interactionTextDisplay = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
                                                    .OfType<IInteractionTextDisplay>()
                                                    .FirstOrDefault();

            CheckNextEvent();
        }

        private void Update()
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
                return;

            EventEntry currentAction = m_correctEventOrder[m_currentIndex];
            
            if (currentAction.Action.UpdateAction())
            {
                EventCompleted();
            }
        }

        private void OnDestroy()
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
                return;

            EventEntry currentAction = m_correctEventOrder[m_currentIndex];
            currentAction.Action.EndAction();
        }

        private void OnGUI()
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
                return;

            EventEntry currentAction = m_correctEventOrder[m_currentIndex];
            EditorGUILayout.LabelField(currentAction.ToString());
        }

        private void EventCompleted()
        {
            EventEntry currentAction = m_correctEventOrder[m_currentIndex];
            currentAction.Action.EndAction();

            m_currentIndex++;

            if (m_currentIndex >= m_correctEventOrder.Count)
            {
                m_onAllEventsCleared?.Invoke();
            }
            else
            {
                CheckNextEvent();
            }
        }

        private void CheckNextEvent()
        {
            EventEntry entry = m_correctEventOrder[m_currentIndex];
            entry.Action.StartAction(this, entry.Object, entry.Data);
        }

        public void BindToInteractable(IInteractable _interactable)
        {
            _interactable.OnInteract += OnInteraction;
        }

        public void UnbindFromInteractable(IInteractable _interactable)
        {
            _interactable.OnInteract -= OnInteraction;
        }

        private void BindToHoverable(IHoverable _hoverable)
        {
            _hoverable.OnHoverStart += OnHover;
        }

        private void OnInteraction(IInteractable _interactable)
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
            {
                Debug.LogWarning("OnInteraction was called with an invalid index!", this);
                return;
            }

            EventEntry entry = m_correctEventOrder[m_currentIndex];

            if (entry.Object != _interactable.Owner)
            {
                _interactable.InteractionWrong();
                return;
            }
        }

        private void OnHover(IInteractable _interactable)
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
            {
                Debug.LogWarning("OnHover was called with an invalid index!", this);
                return;
            }

            EventEntry entry = m_correctEventOrder[m_currentIndex];

            if (entry.Object != _interactable.Owner)
                return;
        }
    }
}