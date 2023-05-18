using Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    [CreateAssetMenu(fileName = "New Interactable", menuName = "Data/Interactable")]
    public class InteractableAsset : ScriptableObject
    {
        public string ObjectName { get => m_objectName; }
        public string Description { get => m_description; }
        public AudioClip HoverSound { get => m_hoverSound; }
        public ClipTextCombination WrongInteractSound { get => m_wrongInteractSound; }
        public ClipTextCombination SuccesfulInteractSound { get => m_succesfulInteractSound; }

        [SerializeField]
        private string m_objectName = "Empty";
        [SerializeField]
        private string m_description = "No description";
        [SerializeField]
        private AudioClip m_hoverSound = null;
        [SerializeField]
        private ClipTextCombination m_wrongInteractSound = null;
        [SerializeField]
        private ClipTextCombination m_succesfulInteractSound = null;
    }
}
