using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    [CreateAssetMenu(fileName = "New Interactable", menuName = "Data/Interactable")]
    public class InteractableAsset : ScriptableObject
    {
        public string Description { get => m_description; }
        public AudioClip HoverSound { get => m_hoverSound; }
        public AudioClip InteractSound { get => m_interactSound; }

        [SerializeField]
        private string m_description = "No description";
        [SerializeField]
        private AudioClip m_hoverSound = null;
        [SerializeField]
        private AudioClip m_interactSound = null;
    }
}
