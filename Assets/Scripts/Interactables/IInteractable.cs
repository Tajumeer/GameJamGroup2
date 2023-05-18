using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Base interface for all interactable objects.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// The name of the object which will be displayed to the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The description of the object which will be displayed to the user.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Is the object being hovered?
        /// </summary>
        public bool IsHovered { get; set; }

        public GameObject Owner { get; }

        public event System.Action<IInteractable> OnInteract;

        public event System.Action<IInteractable> OnHoverStart;

        public event System.Action<IInteractable> OnHoverEnd;

        public event System.Action<IInteractable> OnHover;

        /// <summary>
        /// Tells the object that hovering has started.
        /// </summary>
        /// <returns>Was starting succesful?</returns>
        public bool HoverStart();

        /// <summary>
        /// Tells the object that hovering has ended.
        /// </summary>
        public void HoverEnd();

        /// <summary>
        /// Tells the object that the user is currently hovering it.
        /// </summary>
        /// <returns>Should hovering be ended?</returns>
        public bool Hover();

        /// <summary>
        /// Tells the object that the user wants to interact with the object.
        /// </summary>
        /// <returns>Was the interaction succesful?</returns>
        public bool Interact();

        public bool InteractionSuccesful();
        public bool InteractionWrong();

        public void UpdateData(InteractableAsset _asset);
    }
}
