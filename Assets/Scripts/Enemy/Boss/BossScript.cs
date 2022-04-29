using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BossScript : EnemyTemplate
{
    public static EventManager.SetBossHealthBarValueAction bossTakeDamageAction;

    [Header("Boss name")]
    [SerializeField] private string bossName;

    [Header("Sounds")]
    [SerializeField] private AudioClip deathSound;


    private void Awake()
    {
        maxHealth = enemyStats.health;
        curentHealth = maxHealth;
    }


    private void OnEnable()
    {
        UISystem.ShowBossHealtBar(bossName, maxHealth);
    }


    private void OnDisable()
    {
        UISystem.HideBossHealthBar();
    }


    public override void TakeDamage(int damage)
    {
        curentHealth -= damage;

        bossTakeDamageAction?.Invoke(curentHealth);

        if (curentHealth <= 0)
        {
            GiveExp(enemyStats.deathExp);
            Death();
        }
    }


    public override void Death()
    {
        SoundManager.PlaySoundEffect(deathSound);
        Destroy(gameObject);
    }
}
