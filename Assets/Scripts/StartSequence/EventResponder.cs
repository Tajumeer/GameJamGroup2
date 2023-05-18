using Interactables;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Minigames;

namespace Events
{
    public enum EEventType
    {
        NONE,
        INTERACT,
        HOVER,
        MINIGAME,
        SHOW,
        HIDE
    }

    [System.Serializable]
    public struct EventEntry
    {
        public GameObject Object { get => m_object; }
        public EEventType Type { get => m_eventType; }

        [SerializeField]
        private GameObject m_object;
        [SerializeField]
        private EEventType m_eventType;
    }

    [DisallowMultipleComponent]
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

        [SerializeField]
        private List<EventEntry> m_correctEventOrder = new List<EventEntry>();

        private event System.Action m_onAllEventsCleared;

        private int m_currentIndex;


        private void Start()
        {
            IInteractable[] interactables = GameObject.FindObjectsOfType<GameObject>()
                                                        .Select(o => o.GetComponent<IInteractable>())
                                                        .Where(o => o != null)
                                                        .ToArray();


            foreach (IInteractable interactable in interactables)
            {
                BindToInteractable(interactable);
            }

            IMinigame[] minigames = GameObject.FindObjectsOfType<GameObject>()
                                                .Select(o => o.GetComponent<IMinigame>())
                                                .Where(o => o != null)
                                                .ToArray();

            foreach (IMinigame minigame in minigames)
            {
                BindToMinigames(minigame);
            }
        }

        private void BindToInteractable(IInteractable _interactable)
        {
            _interactable.OnInteract += OnInteraction;
            _interactable.OnHoverStart += OnHover;
        }

        private void BindToMinigames(IMinigame _minigame)
        {
            _minigame.OnMinigameEnded += MinigameFinished;
        }

        private void EventCompleted()
        {
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
            switch (entry.Type)
            {
                case EEventType.NONE:
                case EEventType.INTERACT:
                case EEventType.HOVER:
                    break;
                case EEventType.MINIGAME:
                    entry.Object.GetComponent<IMinigame>().StartMinigame();
                    break;
                case EEventType.SHOW:
                    entry.Object.SetActive(true);
                    EventCompleted();
                    break;
                case EEventType.HIDE:
                    entry.Object.SetActive(false);
                    EventCompleted();
                    break;
                default:
                    break;
            }
        }

        private void MinigameFinished(IMinigame _minigame)
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
            {
                Debug.LogWarning("MinigameFinished was called with an invalid index!", this);
                return;
            }

            EventEntry entry = m_correctEventOrder[m_currentIndex];

            if (entry.Object != _minigame.Owner || entry.Type != EEventType.INTERACT)
                return;

            EventCompleted();
        }

        private void OnInteraction(IInteractable _interactable)
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
            {
                Debug.LogWarning("OnInteraction was called with an invalid index!", this);
                return;
            }

            EventEntry entry = m_correctEventOrder[m_currentIndex];

            if (entry.Object != _interactable.Owner || entry.Type != EEventType.INTERACT)
            {
                _interactable.InteractionWrong();
                return;
            }

            _interactable.InteractionSuccesful();

            EventCompleted();
        }

        private void OnHover(IInteractable _interactable)
        {
            if (m_currentIndex >= m_correctEventOrder.Count)
            {
                Debug.LogWarning("OnHover was called with an invalid index!", this);
                return;
            }

            EventEntry entry = m_correctEventOrder[m_currentIndex];

            if (entry.Object != _interactable.Owner || entry.Type != EEventType.HOVER)
                return;

            EventCompleted();
        }
    }
}