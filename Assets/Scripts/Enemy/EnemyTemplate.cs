using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : MonoBehaviour
{
    public EnemyStats enemyStats;

    [HideInInspector] public int maxHealth;
    [HideInInspector] public int curentHealth;


    /// <summary>
    /// Enemy takes damage. Call <b>Death</b> method when <c>curentHealth</c> &lt;= 0
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    public void TakeDamage(int damage)
    {
        curentHealth -= damage;

        if (curentHealth <= 0) { Death(); }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
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
