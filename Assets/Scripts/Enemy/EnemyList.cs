using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameStructs/EnemyForCurentLevel")]
public class EnemyList : ScriptableObject
{
    public List<GameObject> enemyList;
}
