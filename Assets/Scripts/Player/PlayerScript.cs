using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerScript : MonoBehaviour, IHealth
{
    /// <summary>
    /// Player get hit
    /// </summary>
    public static event EventManager.PlayerGetHitAction PlayerGetHit;

    /// <summary>
    /// Player takes damage
    /// </summary>
    public static event EventManager.SetPlayerHealthBarValueAction SetPlayerHealthBarValue;

    /// <summary>
    /// Player get exp
    /// </summary>
    public static event EventManager.SetPlayerExpBarValueAction SetPlayerExpBarValue;

    /// <summary>
    /// Triggers when player dies
    /// </summary>
    public static event EventManager.PlayerDeathAction PlayerDies;

    [Header("Stats")]
    [SerializeField] private RocketStats rocketStats;

    [Header("Sounds")]
    [SerializeField] private AudioClip getExpSound;
    [SerializeField] private AudioClip levelUpSound;


    private Animation playerGetHitAnimation;

    private int maxHealth;
    private int curentHealth;

    private int expToNextLevel = 100;
    private int curentExp = 0;

    private bool isInvincible = false;
    

    private void Awake()
    {
        playerGetHitAnimation = gameObject.GetComponent<Animation>();
        maxHealth = rocketStats.health;
        curentHealth = maxHealth;
    }


    private void OnEnable()
    {
        EnemyTemplate.GivePlayerExp += GetExp;
    }


    private void OnDisable()
    {
        EnemyTemplate.GivePlayerExp -= GetExp;
    }


    public void RestoreAllHealth()
    {
        curentHealth = maxHealth;
        SetPlayerHealthBarValue?.Invoke(maxHealth);
    }


    public void ResetExp()
    {
        curentExp = 0;
        SetPlayerExpBarValue?.Invoke(0);
    }


    public void GetExp(int expAmount)
    { 
        SoundManager.PlaySoundEffect(getExpSound); 
        curentExp += expAmount;

        if (curentExp >= expToNextLevel)
        {
            //LevelUp
            RestoreAllHealth();
            SoundManager.PlaySoundEffect(levelUpSound);

            curentExp -= expToNextLevel;
        }

        SetPlayerExpBarValue?.Invoke(curentExp);
    }


    /// <summary>
    /// Get player max health
    /// </summary>
    /// <returns>Player max health</returns>
    public int GetMaxHealth()
    {
        return maxHealth;
    }


    /// <summary>
    /// Gives player temporary invincibility, plays invincibility animation
    /// </summary>
    /// <returns></returns>
    /// <param name="invincibilityDuration">Seconds of invincibility</param>
    IEnumerator Invincibility(float invincibilityDuration)
    {
        isInvincible = true;
        playerGetHitAnimation.Play();

        yield return new WaitForSeconds(invincibilityDuration);
        playerGetHitAnimation.Stop();
        isInvincible = false;
    }


    /// <summary>
    /// Deals damage to player
    /// </summary>
    /// <param name="damage">Damage that enemy will take</param>
    public void TakeDamage(int damage)
    {
        if (isInvincible) { return; }

        PlayerGetHit?.Invoke();

        curentHealth -= damage;
        SetPlayerHealthBarValue?.Invoke(curentHealth);

        if (curentHealth <= 0) 
        { 
            Death();
            return; 
        }

        StartCoroutine(Invincibility(1.5f));
    }


    public void Death()
    {
        PlayerDies(gameObject.transform.position);
    
        UISystem.ShowDeathSign();

        Destroy(gameObject);
    }
}
