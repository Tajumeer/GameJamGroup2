using UnityEngine;

namespace Interactables
{
    public interface IInteractionDataUser
    {
        public GameObject Owner { get; }

        public InteractableAsset DataAsset { get; set; }
    }
}
