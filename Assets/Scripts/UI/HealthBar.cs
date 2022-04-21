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
    private float _minAlphaValue = 0.2f;

    /// <summary>
    /// HealthBar <b>alpha-chanel / transparency</b> when player exits UI zone   
    /// </summary>
    private float _maxAlphaValue = 1f;

    private GameObject _player;
    private CanvasGroup _healthbarCanvasGroup;
    private Slider _slider;
    private Image _healthBarFillImage;


    private void Awake()
    {
        PlayerScript.PlayerTakeDamage += PlayerTakesDamage;
         _healthbarCanvasGroup = gameObject.GetComponent<CanvasGroup>();
    }


    private void OnDisable()
    {
        PlayerScript.PlayerTakeDamage -= PlayerTakesDamage;
    }


    private void Start()
    {
        _healthBarFillImage = healthBarFill.GetComponent<Image>();

        GameObject _player = UISystem.GetComponent<UISystem>().player;
        _slider = gameObject.GetComponentInChildren<Slider>();

        if (_slider is null) { return; }
        _slider.maxValue = _player.GetComponentInChildren<PlayerScript>().GetMaxHealth();
        _slider.value = _slider.maxValue;
    }


    /// <summary>
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    public void PlayerTakesDamage(int damage)
    {
        _slider.value -= damage;
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
        int healthPercentage = HealthPercentage(_slider.value, _slider.maxValue);

        if (healthPercentage > 70)
        {
            _healthBarFillImage.color = fullHPColor;
            return;
        }

        if (healthPercentage > 30)
        {
            _healthBarFillImage.color = mediumHPColor;
            return;
        }

        _healthBarFillImage.color = lowHPColor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        _healthbarCanvasGroup.alpha = _minAlphaValue;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        _healthbarCanvasGroup.alpha = _maxAlphaValue;
    }
}
