using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject UISystem;
    public GameObject healthBarFill;

    [Header("HealthBar colors")]
    public Color fullHPColor;
    public Color mediumHPColor;
    public Color lowHPColor;

    [Header("UI elements")]
    [SerializeField] private Slider slider;
    [SerializeField] private Image healthBarFillImage;


    private void Awake()
    {
        PlayerScript.SetPlayerHealthBarValue += PlayerTakesDamage;
        GameDirectorScript.RestartGame += ResetHealthBar;
    }


    private void OnDisable()
    {
        PlayerScript.SetPlayerHealthBarValue -= PlayerTakesDamage;
        GameDirectorScript.RestartGame -= ResetHealthBar;
    }


    private void Start()
    {
        GameObject player = GameDirectorScript.playerGameObject;

        int playerMaxHealth = player.GetComponentInChildren<PlayerScript>().GetMaxHealth();
        slider.maxValue = playerMaxHealth;

        slider.value = slider.maxValue;
    }


    private void ResetHealthBar()
    {
        slider.value = slider.maxValue;
    }


    /// <summary>
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    private void PlayerTakesDamage(int healthBarValue)
    {
        slider.value = healthBarValue;
    }


    /// <summary>
    /// Calculate curent player health percentage  
    /// </summary>
    /// <param name="curentHealth">Curent player health</param>
    /// <param name="maxHealth">Player max health</param>
    /// <returns></returns>
    private int HealthPercentage(float curentHealth, float maxHealth)
    {
        if (curentHealth <= 0 | maxHealth <= 0) { return 0; }

        int healthPercentage = (int)(curentHealth / maxHealth * 100);

        return healthPercentage;
    }


    /// <summary>
    /// Sets player healthbar fill color depending on the curent player health
    /// </summary>
    public void SetFillColor()
    {
        int healthPercentage = HealthPercentage(slider.value, slider.maxValue);

        if (healthPercentage > 70)
        {
            healthBarFillImage.color = fullHPColor;
            return;
        }

        if (healthPercentage > 30)
        {
            healthBarFillImage.color = mediumHPColor;
            return;
        }

        healthBarFillImage.color = lowHPColor;
    }
}
