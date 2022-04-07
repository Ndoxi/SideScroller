using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using System;


[CreateAssetMenu(menuName = "GameStructs/EnemyList")]
public class EnemyList : ScriptableObject
{
    [Header("Enemy list for curent level")]
    public List<Enemy> enemies;
=======

[CreateAssetMenu(menuName = "GameStructs/EnemyForCurentLevel")]
public class EnemyList : ScriptableObject
{
    public List<GameObject> enemyList;
>>>>>>> 69012060979c0cf64be412245d72ab7e5f5a0227
}
