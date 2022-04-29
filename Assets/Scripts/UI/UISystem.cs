using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


/// <summary>
/// Contain references to different game objects in scene, such as player. 
/// </summary>
public class UISystem : MonoBehaviour
{
    [Header("Player death UI")]
    [SerializeField] private GameObject deathSing;

    [Header("Boss UI")]
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private Slider bossHealthBarSlider;
    [SerializeField] private TextMeshProUGUI bossHealthBarText;

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


    public static void ShowBossHealtBar(string bossName, int bossMaxHealth)
    {
        Instance.bossHealthBar.SetActive(true);
        Instance.bossHealthBarSlider.maxValue = bossMaxHealth;
        Instance.bossHealthBarSlider.value = bossMaxHealth;
        Instance.bossHealthBarText.text = bossName;
    }


    public static void HideBossHealthBar()
    {
        if (Instance.bossHealthBar == null) { return; }
        if (Instance.bossHealthBar.activeSelf == false) { return; }

        Instance.bossHealthBar.SetActive(false);
    }
}
