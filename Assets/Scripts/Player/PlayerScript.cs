using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public RocketStats rocketStats;

    private Animation _playerGetHitAnimation;
    private int _maxHealth;
    private int _curentHealth;
    private bool _isInvincible = false;


    private void Awake()
    {
        _playerGetHitAnimation = gameObject.GetComponent<Animation>();
        _maxHealth = rocketStats.health;
        _curentHealth = _maxHealth;
    }


    /// <summary>
    /// Get player max health
    /// </summary>
    /// <returns>Player max health</returns>
    public int GetMaxHealth()
    {
        return _maxHealth;
    }


    /// <summary>
    /// Gives player temporary invincibility, plays invincibility animation
    /// </summary>
    /// <returns></returns>
    /// <param name="invincibilityDuration">Seconds of invincibility</param>
    IEnumerator Invincibility(float invincibilityDuration)
    {
        _isInvincible = true;
        _playerGetHitAnimation.Play();

        yield return new WaitForSeconds(invincibilityDuration);
        _playerGetHitAnimation.Stop();
        _isInvincible = false;
    }


    /// <summary>
    /// Deals damage to player
    /// </summary>
    /// <param name="damage">Damage that enemy will take</param>
    public void TakeDamage(int damage)
    {
        if (_isInvincible) { return; }

        PlayerGetHit();
        PlayerTakeDamage(damage);
        _curentHealth -= damage;

        if (_curentHealth <= 0) 
        { 
            Death();
            return; 
        }

        StartCoroutine(Invincibility(1.5f));
    }


    public void Death()
    {
        PlayerDies(gameObject.transform.position);
        Destroy(gameObject);
    }
}
