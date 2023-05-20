using Interactables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

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

        [SerializeField]
        private List<GameObject> m_buttonObjects = new List<GameObject>();
        [SerializeField]
        private int m_totalRounds = 5;
        [SerializeField]
        private AnimationCurve m_objectCountByRound;
        [SerializeField]
        private AnimationCurve m_showDelayByRound;


        private Dictionary<IInteractable, SpriteRenderer> m_interactableToRenderer = new Dictionary<IInteractable, SpriteRenderer>();
        private List<IInteractable> m_buttons = new List<IInteractable>();
        private List<IInteractable> m_correctOrder = new List<IInteractable>();
        private int m_currentIndex = 0;
        private int m_currentRound = -1;

        private event Action<IMinigame> m_onMinigameStarted;

        private event Action<IMinigame> m_onMinigameEnded;

        private event Action m_onSequenceShowFinished;

        private void Awake()
        {
            foreach (GameObject obj in m_buttonObjects)
            {
                m_buttons.Add(obj.GetComponent<IInteractable>());
            }

            SpriteRenderer renderer;
            foreach (IInteractable item in m_buttons)
            {
                renderer = item.Owner.GetComponent<SpriteRenderer>();
                m_interactableToRenderer.Add(item, renderer);
            }
        }

        public bool EndMinigame()
        {
            m_onMinigameEnded?.Invoke(this);

            return true;
        }

        public bool StartMinigame()
        {
            StartNextRound();

            return true;
        }

        private void ShowFinished()
        {
            foreach (IInteractable interactable in m_buttons)
            {
                interactable.OnInteract += ButtonPressed;
            }
        }

        private void ButtonPressed(IInteractable _button)
        {
            if (_button == m_correctOrder[m_currentIndex])
            {
                m_currentIndex++;
                if (m_currentIndex >= m_correctOrder.Count)
                {
                    StartNextRound();
                }
            }
            else
            {
                LostRound();
            }
        }

        private void StartNextRound()
        {
            m_currentRound++;
            m_currentIndex = 0;

            if (CheckForWin())
            {
                EndMinigame();
                return;
            }

            foreach (IInteractable interactable in m_buttons)
            {
                interactable.OnInteract -= ButtonPressed;
            }

            m_correctOrder = CreateSequence((int)m_objectCountByRound.Evaluate(m_currentRound));
            StartCoroutine(ShowSequence(m_correctOrder, m_showDelayByRound.Evaluate(m_currentRound)));

            m_onSequenceShowFinished += ShowFinished;
        }

        private bool CheckForWin()
        {
            return m_currentRound >= m_totalRounds;
        }

        private void LostRound()
        {
            m_currentRound = -1;
            StartNextRound();
        }

        private List<IInteractable> CreateSequence(int _length)
        {
            List<IInteractable> returnValue = new List<IInteractable>();

            for (int i = 0; i < _length; i++)
            {
                returnValue.Add(m_buttons.Random());
            }

            return returnValue;
        }

        private IEnumerator ShowSequence(List<IInteractable> _order, float _delay)
        {
            int index = 0;
            Color colorCache;
            while (index < _order.Count)
            {
                colorCache = m_interactableToRenderer[_order[index]].color;
                m_interactableToRenderer[_order[index]].color = Color.black;
                
                yield return new WaitForSeconds(_delay);

                m_interactableToRenderer[_order[index]].color = colorCache;

                yield return new WaitForSeconds(_delay * 0.5f);

                index++;
            }

            m_onSequenceShowFinished?.Invoke();
        }
    }

}