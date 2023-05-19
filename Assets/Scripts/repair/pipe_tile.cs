using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_tile : MonoBehaviour
{

    [SerializeField] private GameObject _highlight;

    private void Awake()
    {
        _highlight.SetActive(false);
    }
    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
