using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public interface IHoverable
    {
        public GameObject Owner { get; }
        /// <summary>
        /// Is the object being hovered?
        /// </summary>
        public bool IsHovered { get; set; }

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
    }
}
