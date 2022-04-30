using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;


public class MenuManager : MonoBehaviour
{      
    public static Action CloseMenuAction;

    [Header("Hint for player")]
    [SerializeField] private GameObject hintGO;

    [Header("Win message")]
    [SerializeField] private GameObject winMessageGO;

    private void Start()
    {
        StartCoroutine(ShowHint());
    }


    public static void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CloseMenuAction?.Invoke();
        }
    }


    public void ShowWinMessage()
    {
        if (hintGO == null) { return; }
        winMessageGO.SetActive(true);
    }


    IEnumerator ShowHint()
    {
        yield return new WaitForSeconds(0.75f);

        hintGO.SetActive(true);
        yield return new WaitForSeconds(7.5f);

        hintGO.SetActive(false);
    }
}