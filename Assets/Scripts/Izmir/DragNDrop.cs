using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 mouseWPos;
    Vector3 tempPos;
    [SerializeField] bool freezeDragY;
    [SerializeField] bool freezeDragX;
    [SerializeField] float dragSpeed = 10;

    private void Start()
    {

        tempPos = transform.position;
        
    }

    private Vector3 GetMouseWorldPostion()
    {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {

        mouseWPos = GetMouseWorldPostion();

        if (freezeDragY)
        {
            mouseWPos.y = tempPos.y;
        }
        else if (freezeDragX)
        {
            mouseWPos.x = tempPos.x;
        }

        mousePositionOffset = gameObject.transform.position - mouseWPos;



    }
    private void OnMouseDrag()
    {
        mouseWPos = GetMouseWorldPostion();

        if (freezeDragY)
        {
            mouseWPos.y = tempPos.y;
        }
        else if (freezeDragX)
        {
            mouseWPos.x = tempPos.x;
        }


        transform.position = Vector3.MoveTowards(transform.position, mouseWPos + mousePositionOffset, dragSpeed * Time.deltaTime);
        //transform.position = mouseWPos +  mousePositionOffset;

    }
}
