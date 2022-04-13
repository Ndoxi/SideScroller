using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    [SerializeField] List<GameObject> gameMenus;

    public void ShowMeinMenu(GameObject mainMenu)
    {
        foreach (GameObject menu in gameMenus)
        {
            if (menu.activeSelf)
            {
                return;
            }
        }

        mainMenu.SetActive(true);
    }


    public void ClickButton(GameObject buttonGO) 
    {
        Button button = buttonGO.GetComponent<Button>();
        if (button == null) { return; }

        button.onClick.Invoke();
    }


    public void SelectedFirst(GameObject firstSelected)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
