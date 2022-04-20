using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CloseMenu : MonoBehaviour
{
    [SerializeField] private Button exitButton;


    private void OnEnable()
    {
        MenuManager.CloseMenuAction += CloseMenuViaButton;
    }


    private void OnDisable()
    {
        MenuManager.CloseMenuAction -= CloseMenuViaButton;
    }


    private void CloseMenuViaButton()
    {
        exitButton.onClick.Invoke();
    }
}
