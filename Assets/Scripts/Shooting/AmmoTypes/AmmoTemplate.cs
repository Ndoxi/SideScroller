using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Main template for all ammo types. 
/// <br></br>
/// Contains <b>bullet prefab</b> and <b>ammo data</b> for curent ammo type.
/// </summary>
public abstract class AmmoTemplate : MonoBehaviour
{
    public static event EventManager.PlayerShootAction PlayerShoot;

    [Header("Information about ammo")]
    public GameObject bulletPrefab;
    public AmmoData ammoData;

    [HideInInspector]
    public float _nextFire = 0;

    /// <summary>
    /// Defines ammo behavior. <b>Must</b> instantiate bullet from <b>bullet prefab</b> and set parameters for bullets, 
    /// such as speed, damage and flight direction.  
    /// <br></br>
    /// <example>
    /// <b>Example:</b> Creation of bullet, wich would fly in positive direction of <b>X</b> axis
    /// <code>
    /// if (_nextFire &gt; time) return;
    /// 
    ///   _nextFire = time + ammoData.fireRate / fireRateMult;
    /// 
    ///    GameObject go = Instantiate(bulletPrefab);
    ///   go.transform.position = turetPos;
    ///   Bullet _bullet = go.GetComponent&lt;Bullet&gt;();
    ///   _bullet.SetSpeed(ammoData.speed* speedMult);
    ///   _bullet.SetDirection(0);
    ///   _bullet.SetDamage(ammoData.damage* damageMult);
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="turetPos">Position of turet. Bullets must be instantiated at this position.</param>
    /// <param name="time">The time at begining of this frame. 
    /// For the method to work correctly, this variable must be equal to <c>Time.time</c></param>
    /// <param name="damageMult">Bullet damage multiplier.</param>
    /// <param name="speedMult">Bullet speed multiplier.</param>
    /// <param name="fireRateMult">Bullet speed multiplier.</param>
    /// <remarks>
    /// <b>Example:</b> work with <b>multipliers</b>
    /// <code>
    /// float finalDamage = ammoData.damage * damageMult;
    /// float finalSpeed = ammoData.speed * speedMult;
    /// float finalFireRate = ammoData.fireRate / fireRateMult;
    /// </code>
    /// </remarks>
    public abstract void ShootBullet(Vector2 turetPos, float time, int damageMult = 1, float speedMult = 1, float fireRateMult = 1);

    /// <summary>
    /// Fire shoot ammo event
    /// </summary>
    public void ShootEvent()
    {
        PlayerShoot();
    }
}
