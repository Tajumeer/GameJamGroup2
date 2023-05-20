using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class button_controller_T : MonoBehaviour
{
    public static button_controller_T instance;

    [SerializeField] private Sprite[] buttonSpritesT;
    [SerializeField] private Sprite[] buttonSpritesI;
    [SerializeField] private Sprite[] buttonSpritesL;

    [SerializeField] private Image targetButtonT;
    [SerializeField] private Image targetButtonI;
    [SerializeField] private Image targetButtonL;

    public int buttonTIndex = 0;
    public bool buttonTActive = false;

    public int buttonIIndex = 0;
    public bool buttonIActive = false;

    public int buttonLIndex = 0;
    public bool buttonLActive = false;

    public bool playerField0 = false;
    public bool playerField1 = false;
    public bool playerField2 = false;
    public bool playerField3 = false;
    public bool playerField4 = false;
    public bool playerField5 = false;
    public bool playerField6 = false;
    public bool playerField7 = false;
    public bool playerField8 = false;
    public bool playerField9 = false;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        targetButtonT.sprite = buttonSpritesT[buttonTIndex];
        targetButtonI.sprite = buttonSpritesI[buttonIIndex];
        targetButtonL.sprite = buttonSpritesL[buttonLIndex];
    }

    private void OnDestroy()
    {
        if(this == instance)
        {
            instance = null;
        }
    }

    private void Update()
    {
        if(playerField0 && playerField1 && playerField4 && playerField5 && playerField6 && playerField7 && playerField9)
        {
            Application.Quit();
        }
    }

    public void ChangeSpriteT()
    {
        if(buttonTActive == false)
        {
            buttonTActive = true;
            buttonIActive = false;
            buttonLActive = false;
            targetButtonT.sprite = buttonSpritesT[buttonTIndex];
            return;
        }
        
        if(buttonTIndex+1 <= 3)
        {
            buttonTIndex++;
        } else
        {
            buttonTIndex = 0;
        }
        targetButtonT.sprite = buttonSpritesT[buttonTIndex];
    }

    public void ChangeSpriteI()
    {
        if (buttonIActive == false)
        {
            buttonIActive = true;
            buttonTActive = false;
            buttonLActive = false;
            targetButtonI.sprite = buttonSpritesI[buttonIIndex];
            return;
        }

        if (buttonIIndex + 1 <= 1)
        {
            buttonIIndex++;
        }
        else
        {
            buttonIIndex = 0;
        }
        targetButtonI.sprite = buttonSpritesI[buttonIIndex];
    }

    public void ChangeSpriteL()
    {
        if (buttonLActive == false)
        {
            buttonLActive = true;
            buttonTActive = false;
            buttonIActive = false;
            targetButtonL.sprite = buttonSpritesL[buttonLIndex];
            return;
        }

        if (buttonLIndex + 1 <= 3)
        {
            buttonLIndex++;
        }
        else
        {
            buttonLIndex = 0;
        }
        targetButtonL.sprite = buttonSpritesL[buttonLIndex];
    }
}
