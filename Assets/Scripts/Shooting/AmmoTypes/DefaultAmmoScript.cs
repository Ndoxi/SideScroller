using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultAmmoScript : AmmoTemplate
{
    public override void ShootBullet(Vector2 turetPos, float time, int damageMult = 1, float speedMult = 1, float fireRateMult = 1)
    {
        if (_nextFire > time) { return; }
        
        _nextFire = time + ammoData.fireRate / fireRateMult;

        GameObject go = Instantiate(bulletPrefab);
        go.transform.position = turetPos;
        Bullet _bullet = go.GetComponent<Bullet>();
        _bullet.SetSpeed(ammoData.speed * speedMult);
        _bullet.SetDirection(0);
        _bullet.SetDamage(ammoData.damage * damageMult);
    }
}
