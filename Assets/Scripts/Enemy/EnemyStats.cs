using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains enemy stats and data, such as bullets health or speed.
/// </summary>
[CreateAssetMenu(menuName = "GameStructs/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int health;
    public float speed;
    public int damage;
    public int deathExp;
}
