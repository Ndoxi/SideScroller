using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class BossHealthBar : MonoBehaviour
{
    [Header("Healthbar text")]
    [SerializeField] private TextMeshProUGUI healthBarText;


    public void SetHealthBarText(string text)
    {
        healthBarText.text = text;
    }
}