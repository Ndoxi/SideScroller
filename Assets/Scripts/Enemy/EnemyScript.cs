using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Standart emeny class.
/// </summary>
public class EnemyScript : EnemyTemplate
{ 
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
