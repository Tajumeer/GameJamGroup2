using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    Vector3 mousePositionOffset;
    [SerializeField] bool isDragable;
    [SerializeField] float dragSpeed = 10;

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
}
