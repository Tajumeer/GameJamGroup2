using UnityEngine;

namespace Interactables
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteSetter : MonoBehaviour, IInteractionDataUser
    {
        [SerializeField]
        private InteractableAsset m_data;

        public GameObject Owner => this.gameObject;

        public InteractableAsset DataAsset
        {
            get => m_data;
            set
            {
                m_data = value;

                SetSpriteFromData();
            }
        }

        private void Awake()
        {
            SetSpriteFromData();
        }

        private void SetSpriteFromData()
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            renderer.sprite = m_data.Sprite;
        }
    }

}