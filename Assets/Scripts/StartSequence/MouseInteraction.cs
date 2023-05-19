using Interactables;
using UnityEngine;

namespace StartSequence
{
    public class MouseInteraction : MonoBehaviour
    {
        private Camera m_camera = null;

        private void Awake()
        {
            m_camera = Camera.main;
        }

        private void Update()
        {
            bool isClicking = Input.GetMouseButtonDown(0);
            Vector2 dir = m_camera.ScreenToWorldPoint(Input.mousePosition) - m_camera.transform.position;
            Vector2 origin = m_camera.transform.position;

            RaycastHit2D hit = Physics2D.Raycast(dir, origin);

            if (hit.collider == null)
                return;

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable == null)
                return;

            Debug.DrawLine(hit.transform.position, hit.transform.position + Vector3.up);
            if (isClicking)
            {
                interactable.Interact();
            }
            else
            {
                interactable.IsHovered = true;
            }
        }
    }
}
