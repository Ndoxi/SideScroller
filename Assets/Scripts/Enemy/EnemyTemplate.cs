using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyTemplate : MonoBehaviour
{
    /// <summary>
    /// Give player exp
    /// </summary>
    public static event EventManager.GivePlayerExpAction GivePlayerExp;

    public static event EventManager.EnemyKilledAction enemyKilled;

    public EnemyStats enemyStats;

    [HideInInspector] public int maxHealth;
    [HideInInspector] public int curentHealth;


    /// <summary>
    /// Enemy takes damage. Call <b>Death</b> method when <c>curentHealth</c> &lt;= 0
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    public virtual void TakeDamage(int damage)
    {
        curentHealth -= damage;

        if (curentHealth <= 0) 
        {
            enemyKilled();

            GiveExp(enemyStats.deathExp);
            Death();
        }
    }


    public void GiveExp(int expAmount)
    {
        GivePlayerExp?.Invoke(expAmount);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        PlayerScript playerScript = collision.gameObject.GetComponentInChildren<PlayerScript>();

        if (playerScript == null) { return; }
        playerScript.TakeDamage(enemyStats.damage);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }


    /// <summary>
    /// Call this method when object health &lt;= 0
    /// </summary>
    public abstract void Death();
}
