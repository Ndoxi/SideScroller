using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System;


public class HintText : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI hintTextElement;

    [Header("Hilighted text color")]
    [SerializeField] private Color hilightedTextColor;

    [Header("Actions")]
    [SerializeField] private List<InputActionReference> inputActionReferenceList;

    [Header("Actions")]
    [Range(0, 10)]
    [SerializeField] private List<int> selectedBindingList;

    private List<int> bindingIndexList = new List<int>();


    private void OnEnable()
    {
        UpdateUI();
    }


    private void OnValidate()
    {
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (inputActionReferenceList.Count != selectedBindingList.Count) { return; }
        for (int i = 0; i < inputActionReferenceList.Count; i++)
        {
            GetBindingInfo(i, inputActionReferenceList[i], selectedBindingList[i]);
        }

        UpdateUIText();
    }


    private void GetBindingInfo(int listIndex, InputActionReference inputActionReference, int selectedBinding)
    {
        if (inputActionReference.action.bindings.Count > selectedBinding)
        {
            if (bindingIndexList.Count <= listIndex) 
            {
                bindingIndexList.Add(selectedBinding);
            }
            else
            {
                bindingIndexList[listIndex] = selectedBinding;
            }       
        }
    }


    private void UpdateUIText()
    {
        string moveText = inputActionReferenceList[0].action.GetBindingDisplayString(bindingIndexList[0]);
        string fireText = inputActionReferenceList[1].action.GetBindingDisplayString(bindingIndexList[1]);
        string menuControls = $"{inputActionReferenceList[2].action.GetBindingDisplayString(bindingIndexList[2])} / " +
            $"{inputActionReferenceList[3].action.GetBindingDisplayString(bindingIndexList[3])}";

        string hilightedText = $"{ColorToHex(hilightedTextColor)}";

        string hintText = $"Use <{hilightedText}>{moveText}</color> for movement. " +
            $"Use <{hilightedText}>{fireText}</color> for shooting.\nUse <{hilightedText}>{moveText}</color> " +
            $"and <{hilightedText}>{menuControls}</color> for menu mavigation.";

        hintTextElement.text = hintText;
    }


    private string ColorToHex(Color color)
    {
        Color32 color32 = color;
        return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
    }
}