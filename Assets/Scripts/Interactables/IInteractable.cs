using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Base interface for all interactable objects.
    /// </summary>
    public interface IInteractable
    {
        public GameObject Owner { get; }

        public event System.Action<IInteractable> OnInteract;

        /// <summary>
        /// Tells the object that the user wants to interact with the object.
        /// </summary>
        /// <returns>Was the interaction succesful?</returns>
        public bool Interact();

        public bool InteractionSuccessful();
        public bool InteractionWrong();
    }
}
