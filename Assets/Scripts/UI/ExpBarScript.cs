using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ExpBarScript : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private Slider expBarSlider;


    private void Awake()
    {
        ResetExpBar();
    }

    private void OnEnable()
    {
        GameDirectorScript.RestartGame += ResetExpBar;
        PlayerScript.SetPlayerExpBarValue += SetExpBarValue;
    }


    private void OnDisable()
    {
        GameDirectorScript.RestartGame -= ResetExpBar;
        PlayerScript.SetPlayerExpBarValue -= SetExpBarValue;
    }


    private void SetExpBarMax(int maxValue)
    {
        expBarSlider.maxValue = maxValue;
        ResetExpBar();
    }


    private void SetExpBarValue(int value)
    {
        expBarSlider.value = value;
    }


    private void ResetExpBar()
    {
        expBarSlider.value = 0;
    }
}
