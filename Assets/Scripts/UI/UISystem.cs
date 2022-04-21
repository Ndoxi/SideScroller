using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contain references to different game objects in scene, such as player. 
/// </summary>
public class UISystem : MonoBehaviour
{
    public GameObject deathSing; 

    public static UISystem Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    }


    public static void ShowDeathSign()
    {
        if (Instance.deathSing.activeSelf) { return; }
        Instance.deathSing.SetActive(true);
    }
}
