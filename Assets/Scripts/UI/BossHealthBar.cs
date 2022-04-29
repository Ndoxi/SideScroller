using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class BossHealthBar : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Slider bossHealthBarSlider;


    private void OnEnable()
    {
        BossScript.bossTakeDamageAction += SetBossHealthBarValue;
    }


    private void OnDisable()
    {
        BossScript.bossTakeDamageAction -= SetBossHealthBarValue;
    }


    private void SetBossHealthBarValue(int healthBarValue)
    {
        bossHealthBarSlider.value = healthBarValue;
    }
}