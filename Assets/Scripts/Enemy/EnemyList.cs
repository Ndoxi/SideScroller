using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(menuName = "GameStructs/EnemyList")]
public class EnemyList : ScriptableObject
{
    [Header("Enemy list for curent level")]
    public List<Enemy> enemies;
}
