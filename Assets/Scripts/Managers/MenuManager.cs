using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;


public class MenuManager : MonoBehaviour
{      
    public static Action CloseMenuAction;


    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CloseMenuAction?.Invoke();
        }
    }

}
