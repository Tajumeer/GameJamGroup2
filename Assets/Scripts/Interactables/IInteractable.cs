namespace Interactables
{
    /// <summary>
    /// Base interface for all interactable objects.
    /// </summary>
    public interface IInteractable 
    {
        /// <summary>
        /// The description of the object which will be displayed to the user.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Tells the object that the user is currently hovering it.
        /// </summary>
        /// <returns>Was the hovering accepted?</returns>
        public bool Hover();

        /// <summary>
        /// Tells the object that the user wants to interact with the object.
        /// </summary>
        /// <returns>Was the interaction succesful?</returns>
        public bool Interact();
    }
}
