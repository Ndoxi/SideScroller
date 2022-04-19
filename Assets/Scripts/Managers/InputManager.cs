using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;


public class InputManager : MonoBehaviour
{
    public static PlayerInputActions inputActions;

    public static event Action rebindComplete;
    public static event Action rebindCanceled;

    private void Awake()
    {
        if (inputActions == null) { inputActions = new PlayerInputActions(); }
    }


    public static void DeRebind(InputAction actionToRebind, int bindingIndex, TextMeshProUGUI statusText)
    {
        if (actionToRebind == null) { return; }
        if (bindingIndex < 0) { return; }

        statusText.text = $"Press a {actionToRebind.expectedControlType}";

        actionToRebind.Disable();

        var rebind = actionToRebind.PerformInteractiveRebinding(bindingIndex);

        rebind.OnMatchWaitForAnother(0.1f);

        rebind.OnComplete(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();

            rebindComplete?.Invoke();

        });

        rebind.OnCancel(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();

            rebindCanceled?.Invoke();
        });

        rebind.Start();
    }
}
