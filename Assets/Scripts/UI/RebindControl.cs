using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class RebindControl : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputActionReference inputActionReference;
    [SerializeField] private bool excludeMouce = true;

    [Range(0, 10)]
    [SerializeField] private int selectedBinding;

    //[SerializeField] private GameObject rebindingButton;
    [SerializeField] private InputBinding.DisplayStringOptions displayStringOptions;

    [Header("Binding info - DO NOT EDIT")]
    [SerializeField] private InputBinding inputBinding;

    [Header("UI text")]
    [SerializeField] private Button rebindButton;
    [SerializeField] private TextMeshProUGUI rebindText;

    private int bindingIndex;
    private string actionName;

    private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;


    private void OnEnable()
    {
        rebindButton.onClick.AddListener(() => DoRebind());    

        if (inputActionReference != null)
        {
            GetBindingInfo();
            UpdateUI();
        }
    }


    private void DoRebind()
    {

    }


    private void OnValidate()
    {
        if (inputActionReference == null) { return; }

        GetBindingInfo();
        UpdateUI();
    }


    private void GetBindingInfo()
    {
        if (inputActionReference.action != null) { actionName = inputActionReference.action.name; }

        if (inputActionReference.action.bindings.Count > selectedBinding) 
        {
            inputBinding = inputActionReference.action.bindings[selectedBinding];
            bindingIndex = selectedBinding;
        }
    }


    private void UpdateUI()
    {
        if (rebindText != null)
        {
            if (Application.isPlaying)
            {
                //get info from input manager
            } else
            {
                rebindText.text = inputActionReference.action.GetBindingDisplayString(bindingIndex);
            }
        }
    }

    //public void StartRebindComposite(string actionName, int bindingIndex, TextMeshProUGUI statusText)
    //{
    //    InputAction action = inputActionReference.asset.FindAction(actionName);
    //    if (action == null || action.bindings.Count <= bindingIndex) 
    //    { 
    //        Debug.Log("Could not find action");
    //        return;
    //    }

    //    if (action.bindings[bindingIndex].isComposite)
    //    {


    //    } else
    //    {
    //        StartRebinding();
    //    }
    //}


    //public void StartRebinding()
    //{   
    //    if (rebindingButton == null) { return; }

    //    TextMeshProUGUI buttonText = rebindingButton.GetComponentInChildren<TextMeshProUGUI>();
    //    buttonText.text = "Waiting for input...";


    //    playerInput.currentActionMap.Disable();


    //    //var bindingIndex = inputActionReference.action.bindings.IndexOf(x => x.id.ToString() == bindingId);

    //    _rebindingOperation = inputActionReference.action.PerformInteractiveRebinding()
    //        .WithTargetBinding(bindingIndex)
    //        .OnMatchWaitForAnother(0.1f)
    //        .OnComplete(operation => RebindComplete(buttonText))
    //        .OnCancel(operation => RebindCancel(buttonText))
    //        .Start();
    //}


    //private void RebindComplete(TextMeshProUGUI buttonText)
    //{
    //    int bindingIndex = inputActionReference.action.GetBindingIndexForControl(inputActionReference.action.controls[0]);

    //    buttonText.text = InputControlPath.ToHumanReadableString(
    //        inputActionReference.action.bindings[bindingIndex].effectivePath,
    //        InputControlPath.HumanReadableStringOptions.OmitDevice);

    //    playerInput.currentActionMap.Enable();
    //    _rebindingOperation.Dispose();
    //}


    //private void RebindCancel(TextMeshProUGUI buttonText)
    //{
    //    playerInput.currentActionMap.Enable();
    //    _rebindingOperation.Dispose();
    //}
}
