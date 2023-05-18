using UnityEngine;

namespace Interactables
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteSetter : MonoBehaviour
    {
        [SerializeField]
        private InteractableAsset m_data;

        private void Awake()
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            renderer.sprite = m_data.Sprite;
        }
    }

}