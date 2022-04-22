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

    /// <summary>
    /// HealthBar <b>alpha-chanel / transparency</b> when player enters UI zone   
    /// </summary>
    private float minAlphaValue = 0.2f;

    /// <summary>
    /// HealthBar <b>alpha-chanel / transparency</b> when player exits UI zone   
    /// </summary>
    private float maxAlphaValue = 1f;

    private CanvasGroup healthbarCanvasGroup;
    private Slider slider;
    private Image healthBarFillImage;


    private void Awake()
    {
        PlayerScript.PlayerTakeDamage += PlayerTakesDamage;
        GameDirectorScript.RestartGame += ResetHealthBar;
        healthbarCanvasGroup = gameObject.GetComponent<CanvasGroup>();
    }


    private void OnDisable()
    {
        PlayerScript.PlayerTakeDamage -= PlayerTakesDamage;
        GameDirectorScript.RestartGame -= ResetHealthBar;
    }


    private void Start()
    {
        healthBarFillImage = healthBarFill.GetComponent<Image>();
        slider = gameObject.GetComponentInChildren<Slider>();

        if (slider is null) { return; }

        GameObject player = GameDirectorScript.playerGameObject;

        Debug.Log(player.name);

        int playerMaxHealth = player.GetComponentInChildren<PlayerScript>().GetMaxHealth();
        slider.maxValue = playerMaxHealth;

        slider.value = slider.maxValue;
    }


    private void ResetHealthBar()
    {
        slider.value = slider.maxValue; ;
    }


    /// <summary>
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    private void PlayerTakesDamage(int damage)
    {
        slider.value -= damage;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        healthbarCanvasGroup.alpha = minAlphaValue;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        healthbarCanvasGroup.alpha = maxAlphaValue;
    }
}
