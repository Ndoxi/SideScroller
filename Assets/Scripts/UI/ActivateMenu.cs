using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ActivateMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelected;


    private void OnEnable()
    {
        StartCoroutine(SetFirstSelectedButton());
    }


    IEnumerator SetFirstSelectedButton()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}