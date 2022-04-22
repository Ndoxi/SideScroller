using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour, IHealth
{
    /// <summary>
    /// Player get hit
    /// </summary>
    public static event EventManager.PlayerGetHitAction PlayerGetHit;

    /// <summary>
    /// Player takes damage
    /// </summary>
    public static event EventManager.TakeDamageAction PlayerTakeDamage;

    /// <summary>
    /// Triggers when player dies
    /// </summary>
    public static event EventManager.PlayerDeathAction PlayerDies;

    [SerializeField] private RocketStats rocketStats;

    private Animation playerGetHitAnimation;
    private int maxHealth;
    private int curentHealth;
    private bool isInvincible = false;
    //private bool isDead = false;


    private void Awake()
    {
        playerGetHitAnimation = gameObject.GetComponent<Animation>();
        maxHealth = rocketStats.health;
        curentHealth = maxHealth;

    }


    public void RestoreAllHealth()
    {
        curentHealth = maxHealth;
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

        PlayerGetHit();
        PlayerTakeDamage(damage);
        curentHealth -= damage;

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
