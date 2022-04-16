using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ActivateMenu : MonoBehaviour
{
    [SerializeField] GameObject firstSelected;

    private void OnEnable()
    {
        SelectedFirst();
    }


    public void SelectedFirst()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
