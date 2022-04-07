using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    /// <summary>
    /// Player takes damage
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    public delegate void TakeDamageAction(int damage);

    /// <summary>
    /// Player dies
    /// </summary>  
    public delegate void PlayerDeathAction(Vector2 deathPos);

    /// <summary>
    /// Add ammo to player
    /// </summary>
    public delegate void AddAmmoToPlayerAction(AmmoTemplate ammo);
}
