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


            if (isClicking)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable == null)
                    return;
           
                interactable.Interact();
            }
            else
            {
                IHoverable hoverable = hit.collider.GetComponent<IHoverable>();
                if (hoverable == null)
                    return;

                hoverable.IsHovered = true;
            }
        }
    }
}
