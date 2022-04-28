using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BossScript : EnemyTemplate
{
    [Header("Boss name")]
    [SerializeField] private string bossName;

    [Header("Sounds")]
    [SerializeField] private AudioClip deathSound;

    [Header("UI")]
    [SerializeField] private GameObject bossHealthBar;

    private GameObject healthbar;


    private void Awake()
    {
        maxHealth = enemyStats.health;
        curentHealth = maxHealth;
    }


    private void OnEnable()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("MainCanvas");

        healthbar = null;
        healthbar = Instantiate(bossHealthBar, canvas.transform);
    }


    private void OnDisable()
    {
        Destroy(healthbar);
    }


    public override void Death()
    {
        SoundManager.PlaySoundEffect(deathSound);
        Destroy(gameObject);
    }
}
