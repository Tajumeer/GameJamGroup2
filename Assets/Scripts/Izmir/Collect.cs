using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
    }
}
