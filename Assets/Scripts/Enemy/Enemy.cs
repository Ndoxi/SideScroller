using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Enemy
{
    public enum EnemyType { DEFAULT, METEOR, BOSS };
    public EnemyType enemyType;
    public GameObject enemyPrefab;

    public Enemy(EnemyType enemyType, GameObject enemyPrefab)
    {
        this.enemyType = enemyType;
        this.enemyPrefab = enemyPrefab;
    }
}
