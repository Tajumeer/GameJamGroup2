using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    Vector3 mousePositionOffset;
    [SerializeField] bool isDragable;
    [SerializeField] float dragSpeed = 10;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }
    private Vector3 GetMouseWorldPostion()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {

        if (isDragable)
        {
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPostion();
        }
        else
        {
            Debug.Log("I got pressed");

        }
    }
    private void OnMouseDrag()
    {
        if (isDragable)
        {
            transform.position = Vector3.MoveTowards(transform.position, GetMouseWorldPostion() + mousePositionOffset, dragSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DragNDrop collidedDraggable = GetComponent<DragNDrop>();

        if (collidedDraggable != null)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);

            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }
    }
}
