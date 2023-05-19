using System;
using UnityEngine;

namespace LoadingShipp
{
    public class ShipDragNDrop : MonoBehaviour
    {
        [SerializeField] private float m_moveTime;
        [SerializeField] private Camera m_camera;

        private const float _DISTANCE = Mathf.Infinity;
        private RaycastHit2D m_hit;

        private Vector2 m_mouseForce;
        private Vector3 m_lastPosition;
        private Rigidbody2D m_selectedGameObject;

        private void Update()
        {
            if (m_selectedGameObject)
            {
                m_mouseForce = (GetMousePosition() - (Vector2)m_lastPosition) / Time.deltaTime;
                m_mouseForce = Vector2.ClampMagnitude(m_mouseForce, 100f);
                m_lastPosition = GetMousePosition();
            }

            if (Input.GetMouseButtonUp(0) && m_selectedGameObject)
            {
                m_selectedGameObject.velocity = Vector2.zero;
                m_selectedGameObject.AddForce(m_mouseForce, ForceMode2D.Impulse);
                m_selectedGameObject = null;
            }

            //check if mouse is over the right gameObject
            if (!Input.GetMouseButton(0)) return;
            Vector3 position = m_camera.transform.position;
            m_hit = Physics2D.Raycast(position, GetMousePosition() - (Vector2)position, _DISTANCE);
            Debug.DrawLine(position, GetMousePosition());

            //if nothing is hit return
            if (m_hit.collider == null) return;

            //if cargo collider is hit move the hit transform to mousePosition
            if (!m_hit.collider.CompareTag("Cargo")) return;
            Debug.Log("hit cargo collider");
            if (!m_selectedGameObject)
                m_selectedGameObject = m_hit.rigidbody;
            m_selectedGameObject.transform.position = Vector2.Lerp(m_selectedGameObject.transform.position, GetMousePosition(), m_moveTime);


            //if mouse button is let go add velocity to the rigidbody
        }

        private Vector2 GetMousePosition()
        {
            return m_camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}