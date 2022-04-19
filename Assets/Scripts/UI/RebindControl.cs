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

    [Range(0, 10)]
    [SerializeField] private int selectedBinding;

    [SerializeField] private InputBinding.DisplayStringOptions displayStringOptions;

    [Header("Binding info - DO NOT EDIT")]
    [SerializeField] private InputBinding inputBinding;

    [Header("UI text")]
    [SerializeField] private Button rebindButton;
    [SerializeField] private TextMeshProUGUI rebindButtonText;


    private int bindingIndex;
    private string actionName;


    private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;


    private void OnEnable()
    {
        InputManager.rebindComplete += SaveBindings;
        InputManager.rebindComplete += UpdateUI;

        rebindButton.onClick.AddListener(() => DoRebind());    

        if (inputActionReference != null)
        {
            //InputManager.LoadBindings(inputActionReference.name);
            GetBindingInfo();
            UpdateUI();
        }
    }


    private void OnDisable()
    {
        InputManager.rebindComplete -= SaveBindings;
        InputManager.rebindComplete -= UpdateUI;
    }


    private void DoRebind()
    {
        InputManager.DeRebind(inputActionReference, bindingIndex, rebindButtonText);
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
        if (rebindButtonText != null)
        {
            if (Application.isPlaying)
            {
                rebindButtonText.text = inputActionReference.action.GetBindingDisplayString(bindingIndex);
            } 
            else
            {
                rebindButtonText.text = inputActionReference.action.GetBindingDisplayString(bindingIndex);
            }
        }
    }


    public void SaveBindings()
    {
        string binds = playerInput.actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString(SaveLoadManager.playerControlsKey, binds);
    }
}
