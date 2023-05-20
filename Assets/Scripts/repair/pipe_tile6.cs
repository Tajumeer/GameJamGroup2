using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_tile6 : MonoBehaviour
{

    [SerializeField] private GameObject _highlight;
    [SerializeField] private Sprite[] playerTPipes;
    [SerializeField] private Sprite[] playerIPipes;
    [SerializeField] private Sprite[] playerLPipes;

    private SpriteRenderer sr;



    private void Awake()
    {
        _highlight.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (button_controller_T.instance.buttonTActive == true)
        {
            sr.sprite = playerTPipes[button_controller_T.instance.buttonTIndex];
            if (button_controller_T.instance.buttonTIndex == 2)
            {
                button_controller_T.instance.playerField6 = true;
                return;
            }
            button_controller_T.instance.playerField6 = false;
            return;
        }
        if (button_controller_T.instance.buttonIActive == true)
        {
            sr.sprite = playerIPipes[button_controller_T.instance.buttonIIndex];
            button_controller_T.instance.playerField6 = false;
            return;
        }
        if (button_controller_T.instance.buttonLActive == true)
        {
            sr.sprite = playerLPipes[button_controller_T.instance.buttonLIndex];
            button_controller_T.instance.playerField6 = false;
            return;
        }
    }

}
