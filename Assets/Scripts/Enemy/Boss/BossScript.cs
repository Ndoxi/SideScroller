using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BossScript : EnemyTemplate
{
    [Header("Boss name")]
    [SerializeField] private string bossName;


    private void Awake()
    {
        maxHealth = enemyStats.health;
        curentHealth = maxHealth;
    }


    public override void Death()
    {
        Destroy(gameObject);
    }
}
