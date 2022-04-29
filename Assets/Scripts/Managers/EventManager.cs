using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    /// <summary>
    /// Set player healthbar value
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    public delegate void SetPlayerHealthBarValueAction(int healthAmount);

    /// <summary>
    /// Set player healthbar value
    /// </summary>
    /// <param name="damage">Amount of damage</param>
    public delegate void SetPlayerExpBarValueAction(int expAmount);

    /// <summary>
    /// Give player Exp
    /// </summary>
    /// <param name="expAmount"></param>
    public delegate void GivePlayerExpAction(int expAmount);

    /// <summary>
    /// Set boss healthbar value
    /// </summary>
    /// <param name="damage"></param>
    public delegate void SetBossHealthBarValueAction(int healthAmount);

    /// <summary>
    /// Player dies
    /// </summary>  
    public delegate void PlayerDeathAction(Vector2 deathPos);

    /// <summary>
    /// Add ammo to player
    /// </summary>
    public delegate void AddAmmoToPlayerAction(GameObject ammo);

    public delegate void PlayerGetHitAction();
    public delegate void PlayerShootAction();
    public delegate void EnemyKilledAction();
    public delegate void PickupPowerUpAction();
}
