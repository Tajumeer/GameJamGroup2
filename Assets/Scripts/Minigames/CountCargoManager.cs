using Events;
using Interactables;
using StartSequence;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigames
{
    public class CountCargoManager : MonoBehaviour, IMinigame
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
        private string m_cargoSceneName = "LoadingCargeShipInside";
        [SerializeField]
        private InteractableAsset m_cargoData = null;

        private List<BaseInteractable> m_interactedElements = new List<BaseInteractable>();
        private string m_ownSceneName = string.Empty;
        private List<BaseInteractable> m_addedInteractableComponents = new List<BaseInteractable>();
        private List<AudioSource> m_addedAudioSources = new List<AudioSource>();
        private event Action<IMinigame> m_onMinigameStarted;
        private event Action<IMinigame> m_onMinigameEnded;

        public bool EndMinigame()
        {
            LoadingShipp.ShipDragNDrop shipDragNDrop = GameObject.FindObjectOfType<LoadingShipp.ShipDragNDrop>();
            shipDragNDrop.enabled = true;

            foreach (BaseInteractable item in m_addedInteractableComponents)
            {
                Destroy(item);
            }
            foreach (AudioSource item in m_addedAudioSources)
            {
                Destroy(item);
            }
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.isLoaded && scene.name == m_ownSceneName)
                {
                    foreach (GameObject rootObject in scene.GetRootGameObjects())
                    {
                        rootObject.SetActive(true);
                    }
                }
                if (scene.isLoaded && scene.name == m_cargoSceneName)
                {
                    foreach (GameObject rootObject in scene.GetRootGameObjects())
                    {
                        rootObject.SetActive(false);
                    }
                }
            }

            m_addedAudioSources.Clear();
            m_interactedElements.Clear();
            m_addedInteractableComponents.Clear();
            m_ownSceneName = string.Empty;

            m_onMinigameEnded?.Invoke(this);
            return true;
        }

        public bool StartMinigame()
        {
            m_ownSceneName = SceneManager.GetActiveScene().name;
            foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (go.GetComponent<EventResponder>() != null)
                    continue;
                if (go.GetComponent<MouseInteraction>() != null)
                    continue;
                if (go.GetComponent<Canvas>() != null)
                    continue;
                go.SetActive(false);
            }
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.isLoaded && scene.name == m_cargoSceneName)
                {
                    foreach (GameObject rootObject in scene.GetRootGameObjects())
                    {
                        rootObject.SetActive(true);
                    }
                }
            }

            SetupCargoObjects();

            m_onMinigameStarted?.Invoke(this);
            return true;
        }

        private void SetupCargoObjects()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Cargo");

            LoadingShipp.ShipDragNDrop shipDragNDrop = GameObject.FindObjectOfType<LoadingShipp.ShipDragNDrop>();
            LoadingShipp.LoadingCheck loadingCheck = GameObject.FindObjectOfType<LoadingShipp.LoadingCheck>();
            loadingCheck.enabled = false;
            shipDragNDrop.enabled = false;

            AudioSource source = null;
            foreach (GameObject go in objects)
            {
                source = go.GetComponent<AudioSource>();
                if (source != null)
                {
                    source = go.AddComponent<AudioSource>();
                    m_addedAudioSources.Add(source);
                }
                BaseInteractable inter = go.AddComponent<BaseInteractable>();
                m_addedInteractableComponents.Add(inter);
                inter.DataAsset = m_cargoData;

                inter.OnInteract += ClickedOnCargo;
            }
        }

        private void ClickedOnCargo(IInteractable _interactable)
        {
            BaseInteractable inter = (BaseInteractable)_interactable;
            if (m_interactedElements.Contains(inter))
                return;
            m_interactedElements.Add(inter);

            if (m_interactedElements.Count == m_addedInteractableComponents.Count)
                EndMinigame();
        }
    }
}
