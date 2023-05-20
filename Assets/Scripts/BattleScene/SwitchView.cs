using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    Vector3 cockpit;
    Vector3 rightShipSide;
    private bool isInCockpit = true;

    private void Awake()
    {
        cockpit = new Vector3(0, 0, -1f);
        rightShipSide = new Vector3(19.8600006f, 0, -1);
    }
    public void SwitchCameraPos()
    {
        if (isInCockpit)
        {
            mainCamera.transform.position = rightShipSide;
            isInCockpit = false;
        }

        else if (!isInCockpit)
        {
            mainCamera.transform.position = cockpit;
            isInCockpit = true;
        }
    }
}
